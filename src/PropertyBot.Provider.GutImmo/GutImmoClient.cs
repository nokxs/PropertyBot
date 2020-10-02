using System.Collections.Generic;
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

        internal GutImmoClient(IImmoXXLClient immoXxlClient)
        {
            _immoXxlClient = immoXxlClient;
        }

        public string Name { get; } = "Gut Immo";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            return await _immoXxlClient.GetProperties(GetWebClientOptions());
        }

        private ImmoXXLWebClientOptions GetWebClientOptions()
        {
            var buyIds = EnvironmentConstants.PROVIDER_GUT_IMMO_BUY_IDS.GetAsOptionalEnvironmentVariable("1");
            var categoryIds = EnvironmentConstants.PROVIDER_GUT_IMMO_CATEGORY_IDS.GetAsOptionalEnvironmentVariable("200");

            return new ImmoXXLWebClientOptions("https://www.gutimmo.de", buyIds, categoryIds);
        }
    }
}
