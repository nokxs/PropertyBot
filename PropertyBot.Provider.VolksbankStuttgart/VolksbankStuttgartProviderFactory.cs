using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankStuttgart.Converter;
using PropertyBot.Provider.VolksbankStuttgart.WebClient;

namespace PropertyBot.Provider.VolksbankStuttgart
{
    public class VolksbankStuttgartProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var webClient = new VolksbankWebClient();
            var converter = new VolksbankConverter();

            return new VolksbankStuttgartClient(webClient, converter);
        }
    }
}
