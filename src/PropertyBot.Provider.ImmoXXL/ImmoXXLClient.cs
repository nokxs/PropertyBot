using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoXXL.Converter;
using PropertyBot.Provider.ImmoXXL.WebClient;

namespace PropertyBot.Provider.ImmoXXL
{
    public class ImmoXXLClient : IPropertyProvider
    {
        private readonly IImmoXXLWebClient _webClient;
        private readonly IImmoXXLPropertyConverter _gutImmoPropertyConverter;
        private readonly SettingsReader<ImmoXXLWebClientOptions> _settingsReader;

        public string Name { get; } = "Immo XXL";

        internal ImmoXXLClient(IImmoXXLWebClient webClient, IImmoXXLPropertyConverter gutImmoPropertyConverter, SettingsReader<ImmoXXLWebClientOptions> settingsReader)
        {
            _webClient = webClient;
            _gutImmoPropertyConverter = gutImmoPropertyConverter;
            _settingsReader = settingsReader;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/ImmoXXL.yml");

            var properties = new List<Property>();
            foreach (var setting in settingsContainer.Settings)
            {
                var linkProperties = await _webClient.GetObjects(setting);
                properties.AddRange(_gutImmoPropertyConverter.ToProperties(linkProperties));
            }

            return properties;
        }
    }
}
