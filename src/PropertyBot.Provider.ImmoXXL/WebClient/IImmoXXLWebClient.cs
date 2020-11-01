using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.ImmoXXL.Entity;

namespace PropertyBot.Provider.ImmoXXL.WebClient
{
    internal interface IImmoXXLWebClient
    {
        public Task<IEnumerable<ImmoXXLImmoProperty>> GetObjects(ImmoXXLWebClientOptions options);
    }
}