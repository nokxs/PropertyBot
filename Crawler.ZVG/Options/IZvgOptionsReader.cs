using Crawler.Provider.ZVG.WebClient;

namespace Crawler.Provider.ZVG.Options
{
    internal interface IZvgOptionsReader
    {
        ZvgWebClientOptions GetWebClientOptions();
    }
}