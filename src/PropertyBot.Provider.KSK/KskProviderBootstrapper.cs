using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.KSK.Converter;
using PropertyBot.Provider.KSK.WebClient;

namespace PropertyBot.Provider.KSK
{
    public class KskProviderBootstrapper
    {
        public static void Register(IIocContainer iocContainer)
        {
            iocContainer.AddSingleton<IKskWebClient, KskWebClient>();
            iocContainer.AddSingleton<IKskEstateConverter, KskEstateConverter>();
            iocContainer.AddSingleton<IPropertyProvider, KskClient>();
        }
    }
}
