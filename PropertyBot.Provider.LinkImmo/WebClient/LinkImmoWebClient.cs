using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PropertyBot.Provider.LinkImmo.Entity;

namespace PropertyBot.Provider.LinkImmo.WebClient
{
    internal class LinkImmoWebClient : ILinkImmoWebClient
    {
        private readonly HttpClient _client;

        public LinkImmoWebClient()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<LinkProperty>> GetObjects(LinkImmoWebClientOptions options)
        {
            return null;
        }
    }
}
