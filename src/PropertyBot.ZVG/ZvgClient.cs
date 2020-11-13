using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.ZVG.Converter;
using PropertyBot.Provider.ZVG.WebClient;

namespace PropertyBot.Provider.ZVG
{
    internal class ZvgClient : IPropertyProvider
    {
        private readonly IZvgWebClient _webClient;
        private readonly IZvgObjectConverter _converter;
        private readonly ISettingsReader<ZvgWebClientOptions> _settingsReader;
        private readonly ILogger<ZvgClient> _logger;

        public ZvgClient(
            IZvgWebClient webClient,
            IZvgObjectConverter converter,
            ISettingsReader<ZvgWebClientOptions> settingsReader,
            ILogger<ZvgClient> logger)
        {
            _webClient = webClient;
            _converter = converter;
            _settingsReader = settingsReader;
            _logger = logger;
        }

        public string Name { get; } = "ZVG.com";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/ZVG.yml");

            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var volksbankProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_converter.ToProperties(volksbankProperties));
            }
            
            _logger.LogInfo($"Found {properties.Count} properties");

            return properties;
        }
    }
}
