using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL.Converter;
using PropertyBot.Provider.Base.ImmoXXL.WebClient;

namespace PropertyBot.Provider.Base.ImmoXXL
{
    public class ImmoXXLClient : IImmoXXLClient
    {
        private readonly IImmoXXLWebClient _webClient;
        private readonly IImmoXXLPropertyConverter _gutImmoPropertyConverter;

        internal ImmoXXLClient(IImmoXXLWebClient webClient, IImmoXXLPropertyConverter gutImmoPropertyConverter)
        {
            _webClient = webClient;
            _gutImmoPropertyConverter = gutImmoPropertyConverter;
        }

        public async Task<IEnumerable<Property>> GetProperties(ImmoXXLWebClientOptions options)
        {
            var linkProperties = await _webClient.GetObjects(options);
            return _gutImmoPropertyConverter.ToProperties(linkProperties).ToList();
        }
    }
}
