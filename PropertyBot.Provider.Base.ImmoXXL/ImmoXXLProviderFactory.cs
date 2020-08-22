using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL.Converter;
using PropertyBot.Provider.Base.ImmoXXL.WebClient;

namespace PropertyBot.Provider.Base.ImmoXXL
{
    public class ImmoXXLProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new ImmoXXLWebClient();
            var converter = new ImmoXXLPropertyConverter();

            return new ImmoXXLClient(webClient, converter);
        }
    }
}
