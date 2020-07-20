using System.Threading.Tasks;
using Crawler.ZVG.ZVG.Entity;

namespace Crawler.ZVG.ZVG.WebClient
{
    public interface IZvgWebClient
    {
        Task<ZvgRows> GetZvgObjects(ZvgWebClientOptions options);
    }
}