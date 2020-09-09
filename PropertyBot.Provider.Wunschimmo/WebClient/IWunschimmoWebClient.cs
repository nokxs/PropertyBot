using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.Wunschimmo.Entity;

namespace PropertyBot.Provider.Wunschimmo.WebClient
{
    internal interface IWunschimmoWebClient
    {
        public Task<IEnumerable<WunschimmoProperty>> GetObjects(WunschimmoWebClientOptions options);
    }
}
