using System.Threading.Tasks;
using PropertyBot.Provider.ZVG.Entity;

namespace PropertyBot.Provider.ZVG.WebClient
{
    internal interface IZvgWebClient
    {
        Task<ZvgRows> GetObjects(ZvgWebClientOptions options);
    }
}