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

        public Worker(ILogger<Worker> logger, IEnumerable<IPropertyProvider> propertyProviders, IEnumerable<IMessageSender> messageSenders)
        {
            _logger = logger;
            _propertyProviders = propertyProviders;
            _messageSenders = messageSenders;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var properties = GetAllProperties();

                foreach (var sender in _messageSenders)
                {
                    sender.SendMessage(properties);
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
    }
}
