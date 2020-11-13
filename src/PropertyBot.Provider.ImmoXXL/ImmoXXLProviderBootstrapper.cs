using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoXXL.Converter;
using PropertyBot.Provider.ImmoXXL.WebClient;

namespace PropertyBot.Provider.ImmoXXL
{
    public class ImmoXXLProviderBootstrapper
    {
        public static void Register(IocContainer iocContainer)
        {
            iocContainer.AddSingleton<IImmoXXLWebClient, ImmoXXLWebClient>();
            iocContainer.AddSingleton<IImmoXXLPropertyConverter, ImmoXXLPropertyConverter>();
            iocContainer.AddSingleton<IPropertyProvider, ImmoXXLClient>();
        }
    }
}
