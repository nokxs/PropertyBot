using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankEnz.Converter;
using PropertyBot.Provider.VolksbankEnz.WebClient;

namespace PropertyBot.Provider.VolksbankEnz
{
    public class VolksbankEnzProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new VolksbankWebClient();
            var converter = new VolksbankConverter();

            return new VolksbankEnzClient(webClient, converter);
        }
    }
}
