using System.Collections.Generic;
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

                    services.AddSingleton<IPropertyDataProvider, MongoDbPropertyDataProvider>();

                    services.AddHostedService<Worker>();
                });

        private static void RegisterPropertyProviders(IServiceCollection services)
        {
            services.AddSingleton<IEnumerable<IPropertyProvider>>(serviceProvider =>
            {
                return new[]
                {
                    ZvgProviderFactory.CreateClient()
                };
            });
        }

        private static void RegisterMessageSenders(IServiceCollection services)
        {
            services.AddSingleton<IEnumerable<IMessageSender>>(serviceProvider =>
            {
                var senderDataProvider = new MongoDbSenderDataProvider();
                senderDataProvider.Init();

                return new[]
                {
                    new TelegramSender(senderDataProvider)
                };
            });
        }
    }
}
