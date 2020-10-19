using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.VolksbankEnz.Entity;

namespace PropertyBot.Provider.VolksbankEnz.WebClient
{
    internal interface IVolksbankWebClient
    {
        public Task<IEnumerable<VolksbankProperty>> GetObjects(VolksbankWebClientOptions options);
    }
}