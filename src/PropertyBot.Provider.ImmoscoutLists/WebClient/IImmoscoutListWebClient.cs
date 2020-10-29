using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.ImmoscoutLists.Entity;

namespace PropertyBot.Provider.ImmoscoutLists.WebClient
{
    internal interface IImmoscoutListWebClient
    {
        public Task<IEnumerable<ImmoscoutListProperty>> GetObjects(ImmoscoutListWebClientOptions options);
    }
}