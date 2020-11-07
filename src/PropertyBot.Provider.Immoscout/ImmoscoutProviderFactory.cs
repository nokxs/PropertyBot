using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.Immoscout.Converter;
using PropertyBot.Provider.Immoscout.WebClient;

namespace PropertyBot.Provider.Immoscout
{
    public class ImmoscoutProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new ImmoscoutWebClient();
            var converter = new ImmoscouttConverter();
            var settingsReader = new SettingsReader<ImmoscoutWebClientOptions>();

            return new ImmoscoutClient(webClient, converter, settingsReader);
        }
    }
}
