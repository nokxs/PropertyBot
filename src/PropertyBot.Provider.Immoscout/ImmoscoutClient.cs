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

        private int lastPage = 1;

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
                var result = await _webClient.GetObjects(setting, lastPage);
                lastPage = result.NextPageNumber;
                properties.AddRange(_immoscoutConverter.ToProperties(result.ImmoscoutProperties));
            }

            return properties;
        }
    }
}
