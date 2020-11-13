using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.KSK.Converter;
using PropertyBot.Provider.KSK.WebClient;

namespace PropertyBot.Provider.KSK
{
    public class KskClient : IPropertyProvider
    {
        private readonly IKskWebClient _webClient;
        private readonly IKskEstateConverter _kskEstateConverter;
        private readonly ISettingsReader<KskWebClientOptions> _settingsReader;
        private readonly ILogger<KskWebClient> _logger;

        public KskClient(
            IKskWebClient webClient,
            IKskEstateConverter kskEstateConverter,
            ISettingsReader<KskWebClientOptions> settingsReader,
            ILogger<KskWebClient> logger)
        {
            _webClient = webClient;
            _kskEstateConverter = kskEstateConverter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "Kreissparkasse";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/KSK.yml");

            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var kskProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_kskEstateConverter.ToProperties(kskProperties));
            }
            
            _logger.LogInfo($"Found {properties.Count} properties");

            return properties;
        }
    }
}
