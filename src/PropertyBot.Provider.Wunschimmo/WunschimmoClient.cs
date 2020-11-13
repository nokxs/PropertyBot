using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.Wunschimmo.Converter;
using PropertyBot.Provider.Wunschimmo.WebClient;

namespace PropertyBot.Provider.Wunschimmo
{
    internal class WunschimmoClient : IPropertyProvider
    {
        private readonly IWunschimmoWebClient _webClient;
        private readonly IWunschimmoConverter _wunschimmoConverter;
        private readonly ISettingsReader<WunschimmoWebClientOptions> _settingsReader;
        private readonly ILogger<WunschimmoClient> _logger;

        internal WunschimmoClient(IWunschimmoWebClient webClient, IWunschimmoConverter wunschimmoConverter, ISettingsReader<WunschimmoWebClientOptions> settingsReader, ILogger<WunschimmoClient> logger)
        {
            _webClient = webClient;
            _wunschimmoConverter = wunschimmoConverter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "Wunschimmo";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/Wunschimmo.yml");

            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var volksbankProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_wunschimmoConverter.ToProperties(volksbankProperties));
            }

            _logger.LogInfo($"Found {properties.Count} properties");

            return properties;
        }
    }
}
