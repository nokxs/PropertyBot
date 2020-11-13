using PropertyBot.Common;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.Wunschimmo.Converter;
using PropertyBot.Provider.Wunschimmo.WebClient;

namespace PropertyBot.Provider.Wunschimmo
{
    public class WunschimmoProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new WunschimmoWebClient();
            var converter = new WunschimmoConverter();
            var setttingsReader = new SettingsReader<WunschimmoWebClientOptions>();

            return new WunschimmoClient(webClient, converter, setttingsReader);
        }
    }
}
