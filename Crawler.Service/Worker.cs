using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Crawler.Interface;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Crawler.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEnumerable<IPropertyProvider> _propertyProviders;
        private readonly IEnumerable<IMessageSender> _messageSenders;
        private readonly IDataProvider _dataProvider;

        public Worker(ILogger<Worker> logger, IEnumerable<IPropertyProvider> propertyProviders, IEnumerable<IMessageSender> messageSenders, IDataProvider dataProvider)
        {
            _logger = logger;
            _propertyProviders = propertyProviders;
            _messageSenders = messageSenders;
            _dataProvider = dataProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _dataProvider.Init(); // TODO: Do not init here!

            while (!stoppingToken.IsCancellationRequested)
            {
                var properties = await GetAllProperties().ToListAsync(stoppingToken);
                var newProperties = GetNewProperties(properties).ToList();

                UpdateDatabase(newProperties);

                _logger.LogInformation($"Found {properties.Count} properties, from which {newProperties.Count} are new.");

                foreach (var sender in _messageSenders)
                {
                    await sender.SendMessage(newProperties);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        private async IAsyncEnumerable<Property> GetAllProperties()
        {
            foreach (var provider in _propertyProviders)
            {
                var properties = await provider.GetProperties();
                
                foreach (var property in properties)
                {
                    yield return property;
                }
            }
        }

        private IEnumerable<Property> GetNewProperties(IEnumerable<Property> properties)
        {
            return properties.Where(property => !_dataProvider.Contains(property));
        }

        private void UpdateDatabase(IEnumerable<Property> properties)
        {
            _dataProvider.AddMany(properties);
        }
    }
}
