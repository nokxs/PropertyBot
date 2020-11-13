using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Converter;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.OhneMakler
{
    public class OhneMaklerProviderBoostrapper
    {
        public static void Register(IIocContainer iocContainer)
        {
            iocContainer.AddSingleton<IOhneMaklerWebClient, OhneMaklerWebClient>();
            iocContainer.AddSingleton<IOhneMaklerConverter, OhneMaklerConverter>();
            iocContainer.AddSingleton<IPropertyProvider, OhneMaklerClient>();
        }
    }
}
