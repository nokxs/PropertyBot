using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankStuttgart.Converter;
using PropertyBot.Provider.VolksbankStuttgart.WebClient;

namespace PropertyBot.Provider.VolksbankStuttgart
{
    internal class VolksbankStuttgartClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _volksbankConverter;

        internal VolksbankStuttgartClient(IVolksbankWebClient webClient, IVolksbankConverter volksbankConverter)
        {
            _webClient = webClient;
            _volksbankConverter = volksbankConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var customerId = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_CUSTOMER_ID.GetAsOptionalEnvironmentVariable("144298").ToInt();
            var objectCategory = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_OBJECT_CATEGORY.GetAsOptionalEnvironmentVariable("1").ToInt();
            var geosl = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_GEOSL.GetAsOptionalEnvironmentVariable("004008001019000093");
            var limit = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_LIMIT.GetAsOptionalEnvironmentVariable("100").ToInt();
            var perimeterInKm = EnvironmentConstants.PROVIDER_VBANK_STUTTGART_PERIMETERS_IN_KM.GetAsOptionalEnvironmentVariable("10").ToInt();

            var webClientOptions = new VolksbankWebClientOptions(geosl, perimeterInKm, limit, customerId, objectCategory);

            var volksbankProperties = await _webClient.GetObjects(webClientOptions);
            return _volksbankConverter.ToProperties(volksbankProperties);
        }
    }
}
