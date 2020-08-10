using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.KSK.Entity;

namespace PropertyBot.Provider.KSK.WebClient
{
    internal interface IKskWebClient
    {
        Task<IEnumerable<Estate>> GetObjects(KskWebClientOptions options);
    }
}