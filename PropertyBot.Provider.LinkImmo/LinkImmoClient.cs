using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.LinkImmo.Converter;
using PropertyBot.Provider.LinkImmo.WebClient;

namespace PropertyBot.Provider.LinkImmo
{
    public class LinkImmoClient : IPropertyProvider
    {
        private readonly ILinkImmoWebClient _webClient;
        private readonly ILinkPropertyConverter _linkPropertyConverter;

        internal LinkImmoClient(ILinkImmoWebClient webClient, ILinkPropertyConverter linkPropertyConverter)
        {
            _webClient = webClient;
            _linkPropertyConverter = linkPropertyConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var linkProperties = await _webClient.GetObjects(GetWebClientOptions());
            return _linkPropertyConverter.ToProperties(linkProperties).ToList();
        }
        private LinkImmoWebClientOptions GetWebClientOptions()
        {
            var buyIds = EnvironmentConstants.PROVIDER_LINK_IMMO_BUY_IDS.GetAsOptionalEnvironmentVariable("1");
            var categoryIds = EnvironmentConstants.PROVIDER_LINK_IMMO_CATEGORY_IDS.GetAsOptionalEnvironmentVariable("200");

            return new LinkImmoWebClientOptions(buyIds, categoryIds);
        }
    }
}
