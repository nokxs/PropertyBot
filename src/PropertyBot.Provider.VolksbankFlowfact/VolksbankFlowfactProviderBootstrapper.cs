using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.VolksbankFlowfact.Converter;
using PropertyBot.Provider.VolksbankFlowfact.WebClient;

namespace PropertyBot.Provider.VolksbankFlowfact
{
    public class VolksbankFlowfactProviderBootstrapper
    {
        public static void Register(IIocContainer iocContainer)
        {
            iocContainer.AddSingleton<IVolksbankWebClient, VolksbankWebClient>();
            iocContainer.AddSingleton<IVolksbankConverter, VolksbankConverter>();
            iocContainer.AddSingleton<IPropertyProvider, VolksbankFlowfactClient>();
        }
    }
}
