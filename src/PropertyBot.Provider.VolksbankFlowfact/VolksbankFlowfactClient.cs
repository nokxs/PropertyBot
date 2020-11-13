using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankFlowfact.Converter;
using PropertyBot.Provider.VolksbankFlowfact.WebClient;

namespace PropertyBot.Provider.VolksbankFlowfact
{
    internal class VolksbankFlowfactClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _volksbankConverter;
        private readonly ISettingsReader<VolksbankWebClientOptions> _settingsReader;
        private readonly ILogger<VolksbankFlowfactClient> _logger;

        internal VolksbankFlowfactClient(IVolksbankWebClient webClient,
            IVolksbankConverter volksbankConverter,
            ISettingsReader<VolksbankWebClientOptions> settingsReader,
            ILogger<VolksbankFlowfactClient> logger)
        {
            _webClient = webClient;
            _volksbankConverter = volksbankConverter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "Volksbank Flowfact";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/VolksbankFlowfact.yml");
            var properties = new List<Property>();

            foreach (var setting in settingsContainer.Settings)
            {
                var volksbankProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_volksbankConverter.ToProperties(setting.ClientId, volksbankProperties));
            }

            _logger.LogInfo($"Found {properties.Count} properties");

            return properties;
        }
    }
}
