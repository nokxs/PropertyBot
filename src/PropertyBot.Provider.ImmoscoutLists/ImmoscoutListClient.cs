using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoscoutLists.Converter;
using PropertyBot.Provider.ImmoscoutLists.WebClient;

namespace PropertyBot.Provider.ImmoscoutLists
{
    internal class ImmoscoutListClient : IPropertyProvider
    {
        private readonly IImmoscoutListWebClient _webClient;
        private readonly IImmoscoutListConverter _immoscoutListConverter;

        internal ImmoscoutListClient(IImmoscoutListWebClient webClient, IImmoscoutListConverter immoscoutListConverter)
        {
            _webClient = webClient;
            _immoscoutListConverter = immoscoutListConverter;
        }

        public string Name { get; } = "Immoscout List";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var inputMasks = EnvironmentConstants.PROVIDER_VOLKSBANK_FLOWFACT_INPUT_MASK.GetAsMandatoryEnvironmentVariableList().ToList();
            var clientIds = EnvironmentConstants.PROVIDER_VOLKSBANK_FLOWFACT_CLIENT_ID.GetAsMandatoryEnvironmentVariableList().Select(s => s.ToLong());
            var properties = new List<Property>();

            foreach (var clientId in clientIds)
            {
                var webClientOptions = new ImmoscoutListWebClientOptions("");
                var volksbankProperties = await _webClient.GetObjects(webClientOptions);

                properties.AddRange(_immoscoutListConverter.ToProperties(clientId, volksbankProperties));
            }

            return properties;
        }
    }
}
