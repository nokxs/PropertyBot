using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Converter;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.OhneMakler
{
    internal class OhneMaklerClient : IPropertyProvider
    {
        private readonly IOhneMaklerWebClient _webClient;
        private readonly IOhneMaklerConverter _ohneMaklerConverter;
        private readonly SettingsReader<OhneMaklerClientOptions> _settingsReader;

        internal OhneMaklerClient(IOhneMaklerWebClient webClient,
            IOhneMaklerConverter ohneMaklerConverter,
            SettingsReader<OhneMaklerClientOptions> settingsReader)
        {
            _webClient = webClient;
            _ohneMaklerConverter = ohneMaklerConverter;
            _settingsReader = settingsReader;
        }

        public string Name { get; } = "Volksbank Flowfact";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/VolksbankFlowfact.yml");
            var properties = new List<Property>();

            foreach (var setting in settingsContainer.Settings)
            {
                var volksbankProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_ohneMaklerConverter.ToProperties(setting.ClientId, volksbankProperties));
            }

            return properties;
        }
    }
}
