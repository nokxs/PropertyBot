using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL;

namespace PropertyBot.Provider.RjImmobau
{
    public class RjImmoProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var immoXxlClient = ImmoXXLProviderFactory.CreateClient("RJ Immobau");

            return new RjImmoClient(immoXxlClient);
        }
    }
}
