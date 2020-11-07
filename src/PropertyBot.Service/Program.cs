using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropertyBot.Interface;
using PropertyBot.Persistence.MongoDB;
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
                    RegisterPropertyProviders(services);
                    RegisterMessageSenders(services);
                    RegisterDataProviders(services);

                    services.AddHostedService<Worker>();
                });

        private static void RegisterDataProviders(IServiceCollection services)
        {
            var mongoDbPropertyDataProvider = new MongoDbPropertyDataProvider();
            mongoDbPropertyDataProvider.Init();

            services.AddSingleton<IPropertyDataProvider>(_ => mongoDbPropertyDataProvider);
        }

        private static void RegisterPropertyProviders(IServiceCollection services)
        {
            services.AddSingleton(ZvgProviderFactory.CreateProvider());
            services.AddSingleton(KskProviderFactory.CreateProvider());
            services.AddSingleton(VolksbankImmopoolProviderFactory.CreateProvider());
            services.AddSingleton(ImmoXXLProviderFactory.CreateProvider());
            services.AddSingleton(WunschimmoProviderFactory.CreateProvider());
            services.AddSingleton(VolksbankFlowfactProviderFactory.CreateProvider());
            services.AddSingleton(ImmoscoutListProviderFactory.CreateProvider());
            services.AddSingleton(OhneMaklerProviderFactory.CreateProvider());
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
