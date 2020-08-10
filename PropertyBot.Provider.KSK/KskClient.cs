using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.KSK.Converter;
using PropertyBot.Provider.KSK.Entity;
using PropertyBot.Provider.KSK.WebClient;

namespace PropertyBot.Provider.KSK
{
    public class KskClient : IPropertyProvider
    {
        private readonly IKskWebClient _webClient;
        private readonly IKskEstateConverter _kskEstateConverter;

        internal KskClient(IKskWebClient webClient, IKskEstateConverter kskEstateConverter)
        {
            _webClient = webClient;
            _kskEstateConverter = kskEstateConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var estates = await GetEstates();
            return _kskEstateConverter.ToProperties(estates).ToList();
        }

        private IEnumerable<KskWebClientOptions> GetWebClientOptions()
        {
            var limit = EnvironmentConstants.PROVIDER_KSK_LIMIT.GetAsOptionalEnvironmentVariable("9").ToInt();
            var objectTypesString = EnvironmentConstants.PROVIDER_KSK_MARKETING_USAGE_OBJECT_TYPES.GetAsOptionalEnvironmentVariable("buy_residential_property,buy_residential_house");
            var perimetersString = EnvironmentConstants.PROVIDER_KSK_PERIMETERS_IN_KM.GetAsOptionalEnvironmentVariable("15");
            var regioClientId = EnvironmentConstants.PROVIDER_KSK_REGIO_CLIENT_ID.GetAsOptionalEnvironmentVariable("60350130").ToLong();
            var zipsString = EnvironmentConstants.PROVIDER_KSK_ZIPS.GetAsMandatoryEnvironmentVariable();

            var zips = zipsString.Trim().Split(",");
            var perimeters = perimetersString.Trim().Split(",");
            var zipCounter = 0;

            foreach (var zip in zips)
            {
                var perimeter = perimeters[zipCounter].ToInt();
                var objectTypes = objectTypesString.Split(",");
                yield return new KskWebClientOptions(zip.ToInt(), perimeter, limit, regioClientId, objectTypes);

                zipCounter = perimeters.Length >= 2 ? zipCounter + 1 : zipCounter;
            }
        }

        private async Task<IEnumerable<Estate>> GetEstates()
        {
            var webClientOptions = GetWebClientOptions().ToList();
            var estates = new List<Estate>();

            foreach (var webClientOption in webClientOptions)
            {
                estates.AddRange(await _webClient.GetObjects(webClientOption));
            }

            return estates;
        }
    }
}
