using PropertyBot.Interface;
using PropertyBot.Provider.Base.ImmoXXL;

namespace PropertyBot.Provider.LinkImmo
{
    public class LinkImmoProviderFactory
    {
        public static IPropertyProvider CreateProvider()
        {
            var immoXxlClient = ImmoXXLProviderFactory.CreateClient();

            return new LinkImmoClient(immoXxlClient);
        }
    }
}
