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

            return new KskClient(webClient, converter);
        }
    }
}
