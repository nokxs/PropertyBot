using Microsoft.Extensions.Logging;
using PropertyBot.Common;
using PropertyBot.Common.Ioc;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Provider.Immoscout.Converter;
using PropertyBot.Provider.Immoscout.WebClient;

namespace PropertyBot.Provider.Immoscout
{
    public class ImmoscoutProviderBootstrapper
    {
        public static void Register(IIocContainer iocContainer)
        {
            iocContainer.AddSingleton<IImmoscoutWebClient, ImmoscoutWebClient>();
            iocContainer.AddSingleton<IImmoscoutConverter, ImmoscouttConverter>();
            iocContainer.AddSingleton<SettingsReader<ImmoscoutWebClientOptions>>();
            iocContainer.AddSingleton<IPropertyProvider, ImmoscoutClient>();
        }
    }
}
