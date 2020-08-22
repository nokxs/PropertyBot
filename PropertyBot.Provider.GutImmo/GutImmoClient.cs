using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.GutImmo.Converter;
using PropertyBot.Provider.GutImmo.WebClient;

namespace PropertyBot.Provider.GutImmo
{
    public class GutImmoClient : IPropertyProvider
    {
        private readonly IGutImmoWebClient _webClient;
        private readonly IGutImmoPropertyConverter _gutImmoPropertyConverter;

        internal GutImmoClient(IGutImmoWebClient webClient, IGutImmoPropertyConverter gutImmoPropertyConverter)
        {
            _webClient = webClient;
            _gutImmoPropertyConverter = gutImmoPropertyConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var linkProperties = await _webClient.GetObjects(GetWebClientOptions());
            return _gutImmoPropertyConverter.ToProperties(linkProperties).ToList();
        }
        private GutImmoWebClientOptions GetWebClientOptions()
        {
            var buyIds = EnvironmentConstants.PROVIDER_GUT_IMMO_BUY_IDS.GetAsOptionalEnvironmentVariable("1");
            var categoryIds = EnvironmentConstants.PROVIDER_GUT_IMMO_CATEGORY_IDS.GetAsOptionalEnvironmentVariable("200");

            return new GutImmoWebClientOptions(buyIds, categoryIds);
        }
    }
}
