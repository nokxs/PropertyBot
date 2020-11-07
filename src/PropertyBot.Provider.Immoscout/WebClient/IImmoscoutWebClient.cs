using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.Immoscout.Entity;

namespace PropertyBot.Provider.Immoscout.WebClient
{
    internal interface IImmoscoutWebClient
    {
        public Task<WebClientResult> GetObjects(ImmoscoutWebClientOptions options, int firstPage);
    }
}