using PropertyBot.Common;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.ZVG.Converter;
using PropertyBot.Provider.ZVG.WebClient;

namespace PropertyBot.Provider.ZVG
{
    public static class ZvgProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new ZvgWebClient();
            var converter = new ZvgObjectConverter();
            var settingsReader = new SettingsReader<ZvgWebClientOptions>();

            return new ZvgClient(webClient, converter, settingsReader);
        }
    }
}
