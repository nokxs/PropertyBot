using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankFlowfact.Converter;
using PropertyBot.Provider.VolksbankFlowfact.WebClient;

namespace PropertyBot.Provider.VolksbankFlowfact
{
    internal class VolksbankFlowfactClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _volksbankConverter;
        private readonly SettingsReader<VolksbankWebClientOptions> _settingsReader;

        internal VolksbankFlowfactClient(IVolksbankWebClient webClient,
            IVolksbankConverter volksbankConverter,
            SettingsReader<VolksbankWebClientOptions> settingsReader)
        {
            _webClient = webClient;
            _volksbankConverter = volksbankConverter;
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
                properties.AddRange(_volksbankConverter.ToProperties(setting.ClientId, volksbankProperties));
            }

            return properties;
        }
    }
}
