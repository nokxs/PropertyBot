using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Converter;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.OhneMakler
{
    internal class OhneMaklerClient : IPropertyProvider
    {
        private readonly IOhneMaklerWebClient _webClient;
        private readonly IOhneMaklerConverter _ohneMaklerConverter;
        private readonly ISettingsReader<OhneMaklerClientOptions> _settingsReader;
        private readonly ILogger<OhneMaklerClient> _logger;

        internal OhneMaklerClient(IOhneMaklerWebClient webClient,
            IOhneMaklerConverter ohneMaklerConverter,
            ISettingsReader<OhneMaklerClientOptions> settingsReader,
            ILogger<OhneMaklerClient> logger)
        {
            _webClient = webClient;
            _ohneMaklerConverter = ohneMaklerConverter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "Ohne-Makler.net";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/OhneMakler.yml");
            var properties = new List<Property>();

            foreach (var setting in settingsContainer.Settings)
            {
                var ohneMaklerProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_ohneMaklerConverter.ToProperties(ohneMaklerProperties));
            }
            
            _logger.LogInfo($"Found {properties.Count} properties");

            return properties;
        }
    }
}
