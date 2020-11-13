using PropertyBot.Common.Ioc;
using PropertyBot.Interface;
using PropertyBot.Provider.ZVG.Converter;
using PropertyBot.Provider.ZVG.WebClient;

namespace PropertyBot.Provider.ZVG
{
    public static class ZvgProviderBootstrapper
    {
        public static void Register(IIocContainer iocContainer)
        {
            iocContainer.AddSingleton<IZvgWebClient, ZvgWebClient>();
            iocContainer.AddSingleton<IZvgObjectConverter, ZvgObjectConverter>();
            iocContainer.AddSingleton<IPropertyProvider, ZvgClient>();
        }
    }
}
