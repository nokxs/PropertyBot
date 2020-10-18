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

        public string Name { get; } = "Volksbank (Immopool)";

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var customerIds = EnvironmentConstants.PROVIDER_VOLKSBANK_IMMOPOOL_CUSTOMER_ID.GetAsOptionalEnvironmentVariable("144298").Split(",").Select(id => id.ToInt()).ToList();
            
            var webClientOptions = new VolksbankWebClientOptions("");

            var volksbankProperties = await _webClient.GetObjects(webClientOptions);
            return _volksbankConverter.ToProperties(volksbankProperties);
        }
    }
}
