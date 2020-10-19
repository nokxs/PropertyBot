using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.VolksbankFlowfact.Entity;

namespace PropertyBot.Provider.VolksbankFlowfact.WebClient
{
    internal interface IVolksbankWebClient
    {
        public Task<IEnumerable<VolksbankProperty>> GetObjects(VolksbankWebClientOptions options);
    }
}