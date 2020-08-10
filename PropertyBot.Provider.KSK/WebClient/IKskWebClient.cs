using System.Threading.Tasks;
using PropertyBot.Provider.KSK.Entity;

namespace PropertyBot.Provider.KSK.WebClient
{
    internal interface IKskWebClient
    {
        Task<Root> GetZvgObjects(KskWebClientOptions options);
    }
}