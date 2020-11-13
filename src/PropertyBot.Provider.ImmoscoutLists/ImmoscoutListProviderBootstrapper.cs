using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.ImmoscoutLists.Converter;
using PropertyBot.Provider.ImmoscoutLists.WebClient;

namespace PropertyBot.Provider.ImmoscoutLists
{
    public class ImmoscoutListProviderBootstrapper
    {
        public static void Register(IocContainer iocContainer)
        {
            iocContainer.AddSingleton<IImmoscoutListWebClient, ImmoscoutListWebClient>();
            iocContainer.AddSingleton<IImmoscoutListConverter, ImmoscoutListConverter>();
            iocContainer.AddSingleton<IPropertyProvider, ImmoscoutListClient>();
        }
    }
}
