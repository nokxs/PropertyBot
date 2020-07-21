using Crawler.Provider.ZVG.Converter;
using Crawler.Provider.ZVG.Options;
using Crawler.Provider.ZVG.WebClient;

namespace Crawler.Provider.ZVG
{
    public static class ZvgProviderFactory
    {
        public static ZvgClient CreateClient()
        {
            IZvgWebClient webClient = new ZvgWebClient();
            IZvgOptionsReader optionsReader = new ZvgOptionsReader();
            IZvgObjectConverter converter = new ZvgObjectConverter();

            return new ZvgClient(webClient, optionsReader, converter);
        }
    }
}
