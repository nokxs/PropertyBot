using Crawler.ZVG.ZVG.WebClient;

namespace Crawler.ZVG.ZVG.Options
{
    public interface IZvgOptionsReader
    {
        ZvgWebClientOptions GetWebClientOptions();
    }
}