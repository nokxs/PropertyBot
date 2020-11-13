using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankImmopool.Converter;
using PropertyBot.Provider.VolksbankImmopool.WebClient;

namespace PropertyBot.Provider.VolksbankImmopool
{
    public class VolksbankImmopoolProviderBootstrapper
    {
        public static void Register(IIocContainer iocContainer)
        {
            iocContainer.AddSingleton<IVolksbankWebClient, VolksbankWebClient>();
            iocContainer.AddSingleton<IVolksbankConverter, VolksbankConverter>();
            iocContainer.AddSingleton<IPropertyProvider, VolksbankImmopoolClient>();
        }
    }
}
