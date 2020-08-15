using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.VolksbankImmopool.Entity;

namespace PropertyBot.Provider.VolksbankImmopool.WebClient
{
    internal interface IVolksbankWebClient
    {
        public Task<IEnumerable<VolksbankProperty>> GetObjects(VolksbankWebClientOptions options);
    }
}