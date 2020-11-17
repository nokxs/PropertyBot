using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.OhneMakler.Converter;
using PropertyBot.Provider.OhneMakler.WebClient;

namespace PropertyBot.Provider.OhneMakler
{
    public class ImmosuchmaschineProviderBoostrapper
    {
        public static void Register(IIocContainer iocContainer)
        {
            iocContainer.AddSingleton<IImmosuchmaschineWebClient, ImmosuchmaschineWebClient>();
            iocContainer.AddSingleton<IImmosuchmaschineConverter, ImmosuchmaschineConverter>();
            iocContainer.AddSingleton<IPropertyProvider, ImmosuchmaschineClient>();
        }
    }
}
