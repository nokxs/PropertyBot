using System.Collections.Generic;
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

        public string Name { get; } = "Volksbank Neckar-Enz";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var inputMasks = EnvironmentConstants.PROVIDER_VOLKSBANK_ENZ_INPUT_MASK.GetAsMandatoryEnvironmentVariable().Replace(" ", string.Empty).Split(",");

            var webClientOptions = new VolksbankWebClientOptions(inputMasks);

            var volksbankProperties = await _webClient.GetObjects(webClientOptions);
            return _volksbankConverter.ToProperties(volksbankProperties);
        }
    }
}
