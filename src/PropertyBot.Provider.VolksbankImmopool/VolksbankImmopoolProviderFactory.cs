using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankImmopool.Converter;
using PropertyBot.Provider.VolksbankImmopool.WebClient;

namespace PropertyBot.Provider.VolksbankImmopool
{
    public class VolksbankImmopoolProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new VolksbankWebClient();
            var converter = new VolksbankConverter();
            var settingsReader = new SettingsReader<VolksbankWebClientOptions>();

            return new VolksbankImmopoolClient(webClient, converter, settingsReader);
        }
    }
}
