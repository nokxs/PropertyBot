using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL;
using PropertyBot.Provider.Base.ImmoXXL.WebClient;

namespace PropertyBot.Provider.LinkImmo
{
    public class LinkImmoClient : IPropertyProvider
    {
        private readonly IImmoXXLClient _immoXxlClient;

        public LinkImmoClient(IImmoXXLClient immoXxlClient)
        {
            _immoXxlClient = immoXxlClient;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            return await _immoXxlClient.GetProperties(GetWebClientOptions());
        }
        
        private ImmoXXLWebClientOptions GetWebClientOptions()
        {
            var buyIds = EnvironmentConstants.PROVIDER_LINK_IMMO_BUY_IDS.GetAsOptionalEnvironmentVariable("1");
            var categoryIds = EnvironmentConstants.PROVIDER_LINK_IMMO_CATEGORY_IDS.GetAsOptionalEnvironmentVariable("200");

            return new ImmoXXLWebClientOptions("https://www.link-immobilien.info", buyIds, categoryIds);
        }
    }
}
