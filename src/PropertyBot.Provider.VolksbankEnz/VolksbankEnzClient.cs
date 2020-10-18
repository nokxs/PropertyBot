using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankEnz.Converter;
using PropertyBot.Provider.VolksbankEnz.WebClient;

namespace PropertyBot.Provider.VolksbankEnz
{
    internal class VolksbankEnzClient : IPropertyProvider
    {
        private readonly IVolksbankWebClient _webClient;
        private readonly IVolksbankConverter _volksbankConverter;

        internal VolksbankEnzClient(IVolksbankWebClient webClient, IVolksbankConverter volksbankConverter)
        {
            _webClient = webClient;
            _volksbankConverter = volksbankConverter;
        }

        public string Name { get; } = "Volksbank Neckar-Enz";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var inputMasks = EnvironmentConstants.PROVIDER_VOLKSBANK_ENZ_INPUT_MASK.GetAsOptionalEnvironmentVariable("DA42D4E4-D160-44A1-A69E-246A39095EFE").Split(",");

            var webClientOptions = new VolksbankWebClientOptions(inputMasks);

            var volksbankProperties = await _webClient.GetObjects(webClientOptions);
            return _volksbankConverter.ToProperties(volksbankProperties);
        }
    }
}
