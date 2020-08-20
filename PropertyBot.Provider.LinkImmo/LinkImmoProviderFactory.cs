using PropertyBot.Interface;
using PropertyBot.Provider.LinkImmo.Converter;
using PropertyBot.Provider.LinkImmo.WebClient;

namespace PropertyBot.Provider.LinkImmo
{
    public class LinkImmoProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new LinkImmoWebClient();
            var converter = new LinkPropertyConverter();

            return new LinkImmoClient(webClient, converter);
        }
    }
}
