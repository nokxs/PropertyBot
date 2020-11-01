using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Provider.Base.ImmoXXL.Entity;

namespace PropertyBot.Provider.Base.ImmoXXL.WebClient
{
    internal interface IImmoXXLWebClient
    {
        public Task<IEnumerable<ImmoXXLImmoProperty>> GetObjects(ImmoXXLWebClientOptions options);
    }
}