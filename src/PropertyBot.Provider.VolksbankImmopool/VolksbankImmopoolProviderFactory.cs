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

            return new VolksbankImmopoolClient(webClient, converter);
        }
    }
}
