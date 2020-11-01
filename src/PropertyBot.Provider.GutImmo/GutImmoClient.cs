using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL;
using PropertyBot.Provider.Base.ImmoXXL.WebClient;

namespace PropertyBot.Provider.GutImmo
{
    public class GutImmoClient : IPropertyProvider
    {
        private readonly IImmoXXLClient _immoXxlClient;
        private readonly SettingsReader<ImmoXXLWebClientOptions> _settingsReader;

        internal GutImmoClient(IImmoXXLClient immoXxlClient, SettingsReader<ImmoXXLWebClientOptions> settingsReader)
        {
            _immoXxlClient = immoXxlClient;
            _settingsReader = settingsReader;
        }

        public string Name { get; } = "Gut Immo";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var options = await GetWebClientOptions();

            var properties = new List<Property>();
            foreach (var option in options)
            {
                properties.AddRange(await _immoXxlClient.GetProperties(option));
            }

            return properties;
        }

        private async Task<IEnumerable<ImmoXXLWebClientOptions>> GetWebClientOptions()
        {
            var settingsContainer = await _settingsReader.ReadSettings("providers/GutImmo.yml");
            
            foreach (var setting in settingsContainer.Settings)
            {
                setting.BaseUri = "https://www.gutimmo.de";
            }

            return settingsContainer.Settings;
        }
    }
}
