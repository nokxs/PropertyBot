using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.LinkImmo.Entity;

namespace PropertyBot.Provider.LinkImmo.WebClient
{
    internal interface ILinkImmoWebClient
    {
        public Task<IEnumerable<LinkProperty>> GetObjects(LinkImmoWebClientOptions options);
    }
}