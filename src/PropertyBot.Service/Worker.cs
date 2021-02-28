using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoreLinq;
using PropertyBot.Common.Extensions;
using PropertyBot.Interface;

namespace PropertyBot.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEnumerable<IPropertyProvider> _propertyProviders;
        private readonly IEnumerable<IMessageSender> _messageSenders;
        private readonly IPropertyDataProvider _propertyDataProvider;

        private readonly List<string> _alreadySendExceptions = new List<string>();

        public Worker(ILogger<Worker> logger, IEnumerable<IPropertyProvider> propertyProviders, IEnumerable<IMessageSender> messageSenders, IPropertyDataProvider propertyDataProvider)
        {
            _logger = logger;
            _propertyProviders = propertyProviders;
            _messageSenders = messageSenders;
            _propertyDataProvider = propertyDataProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var pollingIntervalInSeconds = EnvironmentConstants.PROPERTY_POLLING_INTERVAL_IN_SECONDS.GetAsOptionalEnvironmentVariable("600").ToInt(); // default is 10 Minutes

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var properties = await GetAllProperties().ToListAsync(stoppingToken);
                    var distinctProperties = properties.DistinctBy(property => property.Id);
                    var newProperties = GetNewProperties(distinctProperties).ToList();

                    await UpdateDatabase(newProperties);

                    _logger.LogInformation($"Found {properties.Count} properties, from which {newProperties.Count} are new.");

                    foreach (var sender in _messageSenders)
                    {
                        await sender.SendProperties(newProperties);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogCritical(e, $"Unexpected exception");
                }

                await Task.Delay(pollingIntervalInSeconds * 1000, stoppingToken);
            }
        }
                    
        private async IAsyncEnumerable<Property> GetAllProperties()
        {
            var propertyGets = _propertyProviders.Select(provider =>
            {
                try
                {
                    return provider.GetProperties();
                }
                catch (Exception e)
                {
                    _logger.LogCritical($"Couldn't retrieve properties from provider '{provider.Name}'", e);

                    if (!_alreadySendExceptions.Contains(e.StackTrace))
                    {
                        _alreadySendExceptions.Add(e.StackTrace);
                        _messageSenders.ForEach(sender => sender.SendMessage($"Couldn't retrieve properties from provider '{provider.Name}.\n\n{e.Message}\n\n{e.StackTrace}'"));
                    }
                }

                return Task.FromResult(Enumerable.Empty<Property>());
            });
            var propertyLists = await Task.WhenAll(propertyGets);

            foreach (var properties in propertyLists)
            {
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

        private async Task UpdateDatabase(IEnumerable<Property> properties)
        {
            if (properties.Any())
            {
                await _propertyDataProvider.AddMany(properties);
            }
        }
    }
}
