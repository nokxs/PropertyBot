using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankFlowfact.Converter;
using PropertyBot.Provider.VolksbankFlowfact.WebClient;

namespace PropertyBot.Provider.VolksbankFlowfact
{
    internal class VolksbankFlowfactClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _volksbankConverter;

        internal VolksbankFlowfactClient(IVolksbankWebClient webClient, IVolksbankConverter volksbankConverter)
        {
            _webClient = webClient;
            _volksbankConverter = volksbankConverter;
        }

        public string Name { get; } = "Volksbank Flowfact";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var inputMasks = EnvironmentConstants.PROVIDER_VOLKSBANK_FLOWFACT_INPUT_MASK.GetAsMandatoryEnvironmentVariableList().ToList();
            var clientIds = EnvironmentConstants.PROVIDER_VOLKSBANK_FLOWFACT_CLIENT_ID.GetAsMandatoryEnvironmentVariableList().Select(s => s.ToLong());
            var properties = new List<Property>();

            foreach (var clientId in clientIds)
            {
                var webClientOptions = new VolksbankWebClientOptions(inputMasks, clientId);
                var volksbankProperties = await _webClient.GetObjects(webClientOptions);

                properties.AddRange(_volksbankConverter.ToProperties(clientId, volksbankProperties));
            }

            return properties;
        }
    }
}
