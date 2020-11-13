using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankFlowfact.Converter;
using PropertyBot.Provider.VolksbankFlowfact.WebClient;

namespace PropertyBot.Provider.VolksbankFlowfact
{
    public class VolksbankFlowfactProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new VolksbankWebClient();
            var converter = new VolksbankConverter();
            var settingsReader = new SettingsReader<VolksbankWebClientOptions>();

            return new VolksbankFlowfactClient(webClient, converter, settingsReader);
        }
    }
}
