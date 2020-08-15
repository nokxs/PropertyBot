using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankStuttgart.Converter;
using PropertyBot.Provider.VolksbankStuttgart.WebClient;

namespace PropertyBot.Provider.VolksbankStuttgart
{
    internal class VolksbankClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _volksbankConverter;

        internal VolksbankClient(IVolksbankWebClient webClient, IVolksbankConverter volksbankConverter)
        {
            _webClient = webClient;
            _volksbankConverter = volksbankConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var customerIds = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_CUSTOMER_ID.GetAsOptionalEnvironmentVariable("144298").Split(",").Select(id => id.ToInt()).ToList();
            var geoSls = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_GEOSL.GetAsOptionalEnvironmentVariable("004008001019000093").Split(",");
            var perimetersInKm = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_PERIMETERS_IN_KM.GetAsOptionalEnvironmentVariable("10").Split(",").Select(perimeter => perimeter.ToInt()).ToList();
            var objectCategory = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_OBJECT_CATEGORY.GetAsOptionalEnvironmentVariable("1").ToInt();
            var limit = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_LIMIT.GetAsOptionalEnvironmentVariable("100").ToInt();

            AssertValuesValid(customerIds, geoSls, perimetersInKm);

            var webClientOptions = new VolksbankWebClientOptions(geoSls, perimetersInKm, limit, customerIds, objectCategory);

            var volksbankProperties = await _webClient.GetObjects(webClientOptions);
            return _volksbankConverter.ToProperties(volksbankProperties);
        }

        private void AssertValuesValid(IEnumerable<int> customerIds, IEnumerable<string> geoSls, IEnumerable<int> perimetersInKm)
        {
            if (!(customerIds.Count() == geoSls.Count() && customerIds.Count() == perimetersInKm.Count()))
            {
                throw new ArgumentException("The number of customer ids, GeoSLs and perimiters in km have to match");
            }
        }
    }
}
