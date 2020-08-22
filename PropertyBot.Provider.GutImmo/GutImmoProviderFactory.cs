using PropertyBot.Interface;
using PropertyBot.Provider.GutImmo.Converter;
using PropertyBot.Provider.GutImmo.WebClient;

namespace PropertyBot.Provider.GutImmo
{
    public class GutImmoProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new GutImmoWebClient();
            var converter = new GutImmoPropertyConverter();

            return new GutImmoClient(webClient, converter);
        }
    }
}
