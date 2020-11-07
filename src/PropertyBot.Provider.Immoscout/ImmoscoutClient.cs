using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.Immoscout.Converter;
using PropertyBot.Provider.Immoscout.WebClient;

namespace PropertyBot.Provider.Immoscout
{
    internal class ImmoscoutClient : IPropertyProvider
    {
        private readonly IImmoscoutWebClient _webClient;
        private readonly IImmoscoutConverter _immoscoutConverter;
        private readonly SettingsReader<ImmoscoutWebClientOptions> _settingsReader;

        internal ImmoscoutClient(IImmoscoutWebClient webClient, IImmoscoutConverter immoscoutConverter, SettingsReader<ImmoscoutWebClientOptions> settingsReader)
        {
            _webClient = webClient;
            _immoscoutConverter = immoscoutConverter;
            _settingsReader = settingsReader;
        }

        public string Name { get; } = "Immobilienscout24";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/Immobilienscout24.yml");
            
            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var immoscoutListProperties = await _webClient.GetObjects(setting, 1);
                properties.AddRange(_immoscoutConverter.ToProperties(immoscoutListProperties.ImmoscoutProperties));
            }

            return properties;
        }
    }
}
