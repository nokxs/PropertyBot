using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.OhneMakler.Entity;

namespace PropertyBot.Provider.OhneMakler.WebClient
{
    internal interface IOhneMaklerWebClient
    {
        public Task<IEnumerable<OhneMaklerProperty>> GetObjects(OhneMaklerClientOptions options);
    }
}