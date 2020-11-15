using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropertyBot.Common;
using PropertyBot.Common.Ioc;
using PropertyBot.Common.Logging;
using PropertyBot.Common.Settings;
using PropertyBot.Interface;
using PropertyBot.Persistence.MongoDB;
using PropertyBot.Provider.Immoscout;
using PropertyBot.Provider.ImmoscoutLists;
using PropertyBot.Provider.ImmoXXL;
using PropertyBot.Provider.KSK;
using PropertyBot.Provider.OhneMakler;
using PropertyBot.Provider.VolksbankFlowfact;
using PropertyBot.Provider.VolksbankImmopool;
using PropertyBot.Provider.Wunschimmo;
using PropertyBot.Provider.ZVG;
using PropertyBot.Sender.Telegram;

namespace PropertyBot.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    RegisterCommon(services);
                    RegisterPropertyProviders(services);
                    RegisterMessageSenders(services);
                    RegisterDataProviders(services);

                    services.AddHostedService<Worker>();
                });

        private static void RegisterCommon(IServiceCollection services)
        {
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddSingleton(typeof(ISettingsReader<>), typeof(SettingsReader<>));
            services.AddSingleton<IHtmlPaginationHelper, HtmlPaginationHelper>();
        }

        private static void RegisterDataProviders(IServiceCollection services)
        {
            var mongoDbPropertyDataProvider = new MongoDbPropertyDataProvider();
            mongoDbPropertyDataProvider.Init();

            services.AddSingleton<IPropertyDataProvider>(_ => mongoDbPropertyDataProvider);
        }

        private static void RegisterPropertyProviders(IServiceCollection services)
        {
            var iocContainer = new IocContainer(services);

            ImmoscoutProviderBootstrapper.Register(iocContainer);
            ImmoscoutListProviderBootstrapper.Register(iocContainer);
            ImmoXXLProviderBootstrapper.Register(iocContainer);
            KskProviderBootstrapper.Register(iocContainer);
            OhneMaklerProviderBoostrapper.Register(iocContainer);
            VolksbankFlowfactProviderBootstrapper.Register(iocContainer);
            VolksbankImmopoolProviderBootstrapper.Register(iocContainer);
            WunschimmoProviderBootstrapper.Register(iocContainer);
            ZvgProviderBootstrapper.Register(iocContainer);
        }

        private static void RegisterMessageSenders(IServiceCollection services)
        {
            var senderDataProvider = new MongoDbSenderDataProvider();
            senderDataProvider.Init();

            var telegramSender = new TelegramSender(senderDataProvider);
            telegramSender.Init();

            services.AddSingleton<IMessageSender>(telegramSender);
        }
    }
}
