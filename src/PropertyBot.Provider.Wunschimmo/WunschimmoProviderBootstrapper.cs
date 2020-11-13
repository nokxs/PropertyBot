using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.Wunschimmo.Converter;
using PropertyBot.Provider.Wunschimmo.WebClient;

namespace PropertyBot.Provider.Wunschimmo
{
    public class WunschimmoProviderBootstrapper
    {
        public static void Register(IIocContainer iocContainer)
        {
            iocContainer.AddSingleton<IWunschimmoWebClient, WunschimmoWebClient>();
            iocContainer.AddSingleton<IWunschimmoConverter, WunschimmoConverter>();
            iocContainer.AddSingleton<IPropertyProvider, WunschimmoClient>();
        }
    }
}
