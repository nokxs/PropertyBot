using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankImmopool.Converter;
using PropertyBot.Provider.VolksbankImmopool.WebClient;

namespace PropertyBot.Provider.VolksbankImmopool
{
    internal class VolksbankImmopoolClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _volksbankConverter;
        private readonly ISettingsReader<VolksbankWebClientOptions> _settingsReader;
        private readonly ILogger<VolksbankImmopoolClient> _logger;

        public VolksbankImmopoolClient(
            IVolksbankWebClient webClient,
            IVolksbankConverter volksbankConverter,
            ISettingsReader<VolksbankWebClientOptions> settingsReader,
            ILogger<VolksbankImmopoolClient> logger)
        {
            _webClient = webClient;
            _volksbankConverter = volksbankConverter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "Volksbank (Immopool)";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/VolksbankImmopool.yml");

            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var volksbankProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_volksbankConverter.ToProperties(volksbankProperties));
            }
            
            _logger.LogInfo($"Found {properties.Count} properties");

            return properties;
        }
    }
}
