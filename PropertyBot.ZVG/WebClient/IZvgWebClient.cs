using System.Threading.Tasks;
using Crawler.Provider.ZVG.Entity;

namespace Crawler.Provider.ZVG.WebClient
{
    internal interface IZvgWebClient
    {
        Task<ZvgRows> GetZvgObjects(ZvgWebClientOptions options);
    }
}