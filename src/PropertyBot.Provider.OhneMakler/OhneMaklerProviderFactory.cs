using PropertyBot.Common;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Converter;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.OhneMakler
{
    public class OhneMaklerProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new OhneMaklerWebClient();
            var converter = new OhneMaklerConverter();
            var settingsReader = new SettingsReader<OhneMaklerClientOptions>();

            return new OhneMaklerClient(webClient, converter, settingsReader);
        }
    }
}
