using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoscoutLists.Converter;
using PropertyBot.Provider.ImmoscoutLists.WebClient;

namespace PropertyBot.Provider.ImmoscoutLists
{
    internal class ImmoscoutListClient : IPropertyProvider
    {
        private readonly IImmoscoutListWebClient _webClient;
        private readonly IImmoscoutListConverter _immoscoutListConverter;
        private readonly SettingsReader<ImmoscoutListWebClientOptions> _settingsReader;

        internal ImmoscoutListClient(IImmoscoutListWebClient webClient, IImmoscoutListConverter immoscoutListConverter, SettingsReader<ImmoscoutListWebClientOptions> settingsReader)
        {
            _webClient = webClient;
            _immoscoutListConverter = immoscoutListConverter;
            _settingsReader = settingsReader;
        }

        public string Name { get; } = "Immoscout List";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/ImmoscoutLists.yml");
            
            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var immoscoutListProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_immoscoutListConverter.ToProperties(immoscoutListProperties));
            }

            return properties;
        }
    }
}
