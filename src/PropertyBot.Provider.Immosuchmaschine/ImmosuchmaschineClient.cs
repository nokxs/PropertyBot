using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Converter;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.OhneMakler
{
    internal class ImmosuchmaschineClient : IPropertyProvider
    {
        private readonly IImmosuchmaschineWebClient _webClient;
        private readonly IImmosuchmaschineConverter _immosuchmaschineConverter;
        private readonly ISettingsReader<ImmosuchmaschineClientOptions> _settingsReader;
        private readonly ILogger<ImmosuchmaschineClient> _logger;

        public ImmosuchmaschineClient(IImmosuchmaschineWebClient webClient,
            IImmosuchmaschineConverter immosuchmaschineConverter,
            ISettingsReader<ImmosuchmaschineClientOptions> settingsReader,
            ILogger<ImmosuchmaschineClient> logger)
        {
            _webClient = webClient;
            _immosuchmaschineConverter = immosuchmaschineConverter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "Immosuchmaschine.de";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/Immosuchmaschine.yml");
            var properties = new List<Property>();

            foreach (var setting in settingsContainer.Settings)
            {
                var immosuchmaschineProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_immosuchmaschineConverter.ToProperties(immosuchmaschineProperties));
            }
            
            _logger.LogInfo($"Found {properties.Count} properties");

            return properties;
        }
    }
}
