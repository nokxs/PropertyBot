using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL.WebClient;

namespace PropertyBot.Provider.Base.ImmoXXL
{
    public interface IImmoXXLClient
    {
        Task<IEnumerable<Property>> GetProperties(ImmoXXLWebClientOptions options);
    }
}