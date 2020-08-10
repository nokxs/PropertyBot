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
        private readonly IPropertyDataProvider _propertyDataProvider;

        public Worker(ILogger<Worker> logger, IEnumerable<IPropertyProvider> propertyProviders, IEnumerable<IMessageSender> messageSenders, IPropertyDataProvider propertyDataProvider)
        {
            _logger = logger;
            _propertyProviders = propertyProviders;
            _messageSenders = messageSenders;
            _propertyDataProvider = propertyDataProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _propertyDataProvider.Init(); // TODO: Do not init here!
            foreach (var sender in _messageSenders)
            {
                sender.Init();
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                var properties = await GetAllProperties().ToListAsync(stoppingToken);
                var newProperties = GetNewProperties(properties).ToList();

                UpdateDatabase(newProperties);

                _logger.LogInformation($"Found {properties.Count} properties, from which {newProperties.Count} are new.");

                foreach (var sender in _messageSenders)
                {
                    await sender.SendMessages(newProperties);
                }

                await Task.Delay(1000 * 60, stoppingToken);
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
            return properties.Where(property => !_propertyDataProvider.Contains(property));
        }

        private void UpdateDatabase(IEnumerable<Property> properties)
        {
            _propertyDataProvider.AddMany(properties);
        }
    }
}
