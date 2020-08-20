using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Interface;
using PropertyBot.Provider.LinkImmo.Converter;
using PropertyBot.Provider.LinkImmo.WebClient;

namespace PropertyBot.Provider.LinkImmo
{
    public class LinkImmoClient : IPropertyProvider
    {
        private readonly ILinkImmoWebClient _webClient;
        private readonly ILinkPropertyConverter _linkPropertyConverter;

        internal LinkImmoClient(ILinkImmoWebClient webClient, ILinkPropertyConverter linkPropertyConverter)
        {
            _webClient = webClient;
            _linkPropertyConverter = linkPropertyConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            return null;
        }
    }
}
