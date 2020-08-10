using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Crawler.Interface;
using Crawler.Persistence.MongoDB;
using Crawler.Provider.ZVG;
using Crawler.Sender.Telegram;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Crawler.Service
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
            services.AddSingleton<IEnumerable<IPropertyProvider>>(_ =>
            {
                return new[]
                {
                    ZvgProviderFactory.CreateClient()
                };
            });
        }

        private static void RegisterMessageSenders(IServiceCollection services)
        {
            services.AddSingleton<IEnumerable<IMessageSender>>(_ =>
            {
                var senderDataProvider = new MongoDbSenderDataProvider();
                senderDataProvider.Init();

                var telegramSender = new TelegramSender(senderDataProvider);
                telegramSender.Init();

                return new[]
                {
                    telegramSender
                };
            });
        }
    }
}
