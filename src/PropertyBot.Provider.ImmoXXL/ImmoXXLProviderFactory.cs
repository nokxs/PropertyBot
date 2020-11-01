using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoXXL.Converter;
using PropertyBot.Provider.ImmoXXL.WebClient;

namespace PropertyBot.Provider.ImmoXXL
{
    public class ImmoXXLProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new ImmoXXLWebClient();
            var converter = new ImmoXXLPropertyConverter();
            var settingsReader = new SettingsReader<ImmoXXLWebClientOptions>();

            return new ImmoXXLClient(webClient, converter, settingsReader);
        }
    }
}
