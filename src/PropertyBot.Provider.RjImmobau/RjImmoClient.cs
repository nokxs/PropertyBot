using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL;
using PropertyBot.Provider.Base.ImmoXXL.WebClient;

namespace PropertyBot.Provider.RjImmobau
{
    public class RjImmoClient : IPropertyProvider
    {
        private readonly IImmoXXLClient _immoXxlClient;
        private readonly SettingsReader<ImmoXXLWebClientOptions> _settingsReader;

        public RjImmoClient(IImmoXXLClient immoXxlClient, SettingsReader<ImmoXXLWebClientOptions> settingsReader)
        {
            _immoXxlClient = immoXxlClient;
            _settingsReader = settingsReader;
        }

        public string Name { get; } = "RJ Immobau";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            return await _immoXxlClient.GetProperties(GetWebClientOptions());
        }
        
        private ImmoXXLWebClientOptions GetWebClientOptions()
        {
            var buyIds = EnvironmentConstants.PROVIDER_RJIMMO_IMMO_BUY_IDS.GetAsOptionalEnvironmentVariable("1");
            var categoryIds = EnvironmentConstants.PROVIDER_RJIMMO_IMMO_CATEGORY_IDS.GetAsOptionalEnvironmentVariable("200");

            return new ImmoXXLWebClientOptions("http://www.rjimmobau.de", buyIds, categoryIds);

            var settingsContainer = await _settingsReader.ReadSettings("providers/GutImmo.yml");

            foreach (var setting in settingsContainer.Settings)
            {
                setting.BaseUri = "https://www.rjimmobau.de";
            }

            return settingsContainer.Settings;
        }
    }
}
