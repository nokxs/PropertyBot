using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoscoutLists.Converter;
using PropertyBot.Provider.ImmoscoutLists.WebClient;

namespace PropertyBot.Provider.ImmoscoutLists
{
    internal class ImmoscoutListClient : IPropertyProvider
    {
        private readonly IImmoscoutListWebClient _webClient;
        private readonly IImmoscoutListConverter _immoscoutListConverter;
        private readonly ISettingsReader<ImmoscoutListWebClientOptions> _settingsReader;
        private readonly ILogger<ImmoscoutListClient> _logger;

        public ImmoscoutListClient(
            IImmoscoutListWebClient webClient,
            IImmoscoutListConverter immoscoutListConverter,
            ISettingsReader<ImmoscoutListWebClientOptions> settingsReader,
            ILogger<ImmoscoutListClient> logger)
        {
            _webClient = webClient;
            _immoscoutListConverter = immoscoutListConverter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "Immoscout List";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/ImmoscoutLists.yml");
            
            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var immoscoutListProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_immoscoutListConverter.ToProperties(immoscoutListProperties));
            }

            _logger.LogInfo($"Found {properties.Count} properties");

            return properties;
        }
    }
}
