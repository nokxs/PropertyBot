using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL;

namespace PropertyBot.Provider.GutImmo
{
    public class GutImmoProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var immoXxlClient = ImmoXXLProviderFactory.CreateClient("Gut Immo");

            return new GutImmoClient(immoXxlClient);
        }
    }
}
