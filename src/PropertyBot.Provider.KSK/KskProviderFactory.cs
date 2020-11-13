using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.KSK.Converter;
using PropertyBot.Provider.KSK.WebClient;

namespace PropertyBot.Provider.KSK
{
    public class KskProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new KskWebClient();
            var converter = new KskEstateConverter();
            var settingsReader = new SettingsReader<KskWebClientOptions>();

            return new KskClient(webClient, converter, settingsReader);
        }
    }
}
