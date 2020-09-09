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
            var regions = EnvironmentConstants.PROVIDER_WUNSCHIMMO_REGIONS.GetAsOptionalEnvironmentVariable("baden-wuerttemberg,stuttgart,stuttgart").Split(";").ToList();
            var objectTypes = EnvironmentConstants.PROVIDER_WUNSCHIMMO_OBJECT_TYPES.GetAsOptionalEnvironmentVariable("haus-kaufen").Split(",");
            var perimetersInKm = EnvironmentConstants.PROVIDER_WUNSCHIMMO_PERIMETERS_IN_KM.GetAsOptionalEnvironmentVariable("10").Split(",").Select(perimeter => perimeter.ToInt()).ToList();

            AssertValuesValid(regions, objectTypes, perimetersInKm);
            List<Property> allProperties = new List<Property>();

            for (int i = 0; i < regions.Count; i++)
            {
                var region = regions[i];
                var objectType = objectTypes[i];
                var perimeter = perimetersInKm[i];

                var webClientOptions = new WunschimmoWebClientOptions(region, perimeter, objectType);
                var wunschimmoProperties = await _webClient.GetObjects(webClientOptions);
                var properties = _wunschimmoConverter.ToProperties(wunschimmoProperties);
                allProperties.AddRange(properties);
            }

            return allProperties;
        }

        private void AssertValuesValid(IEnumerable<string> regions, IEnumerable<string> objectTypes, IEnumerable<int> perimetersInKm)
        {
            if (!(regions.Count() == objectTypes.Count() && regions.Count() == perimetersInKm.Count()))
            {
                throw new ArgumentException("The number of regions, objectTypes and perimeters in km have to match");
            }
        }
    }
}
