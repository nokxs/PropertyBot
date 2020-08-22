using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.GutImmo.Entity;

namespace PropertyBot.Provider.GutImmo.WebClient
{
    internal interface IGutImmoWebClient
    {
        public Task<IEnumerable<GutImmoProperty>> GetObjects(GutImmoWebClientOptions options);
    }
}