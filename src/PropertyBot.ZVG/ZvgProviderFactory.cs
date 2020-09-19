using PropertyBot.Interface;
using PropertyBot.Provider.ZVG.Converter;
using PropertyBot.Provider.ZVG.Options;
using PropertyBot.Provider.ZVG.WebClient;

namespace PropertyBot.Provider.ZVG
{
    public static class ZvgProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            IZvgWebClient webClient = new ZvgWebClient();
            IZvgOptionsReader optionsReader = new ZvgOptionsReader();
            IZvgObjectConverter converter = new ZvgObjectConverter();

            return new ZvgClient(webClient, optionsReader, converter);
        }
    }
}
