using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.VolksbankStuttgart.Entity;

namespace PropertyBot.Provider.VolksbankStuttgart.WebClient
{
    internal interface IVolksbankWebClient
    {
        public Task<IEnumerable<VolksbankProperty>> GetObjects(VolksbankWebClientOptions options);
    }
}