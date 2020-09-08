using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.Wunschimmo.Converter;
using PropertyBot.Provider.Wunschimmo.WebClient;

namespace PropertyBot.Provider.Wunschimmo
{
    internal class WunschimmoClient : IPropertyProvider
    {
        private readonly IWunschimmoWebClient _webClient;
        private readonly IWunschimmoConverter _wunschimmoConverter;

        internal WunschimmoClient(IWunschimmoWebClient webClient, IWunschimmoConverter wunschimmoConverter)
        {
            _webClient = webClient;
            _wunschimmoConverter = wunschimmoConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            //var customerIds = EnvironmentConstants.PROVIDER_VOLKSBANK_IMMOPOOL_CUSTOMER_ID.GetAsOptionalEnvironmentVariable("144298").Split(",").Select(id => id.ToInt()).ToList();
            //var geoSls = EnvironmentConstants.PROVIDER_VOLKSBANK_IMMOPOOL_GEOSL.GetAsOptionalEnvironmentVariable("004008001019000093").Split(",");
            //var perimetersInKm = EnvironmentConstants.PROVIDER_VOLKSBANK_IMMOPOOL_PERIMETERS_IN_KM.GetAsOptionalEnvironmentVariable("10").Split(",").Select(perimeter => perimeter.ToInt()).ToList();
            //var objectCategory = EnvironmentConstants.PROVIDER_VOLKSBANK_IMMOPOOL_OBJECT_CATEGORY.GetAsOptionalEnvironmentVariable("1").ToInt();
            //var limit = EnvironmentConstants.PROVIDER_VOLKSBANK_IMMOPOOL_LIMIT.GetAsOptionalEnvironmentVariable("100").ToInt();

            //AssertValuesValid(customerIds, geoSls, perimetersInKm);

            //var webClientOptions = new WunschimmoWebClientOptions(geoSls, perimetersInKm, limit, customerIds, objectCategory);

            //var volksbankProperties = await _webClient.GetObjects(webClientOptions);
            //return _wunschimmoConverter.ToProperties(volksbankProperties);

            return Enumerable.Empty<Property>();
        }
    }
}
