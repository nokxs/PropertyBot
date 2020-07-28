using System.Collections.Generic;
using Crawler.Interface;
using Crawler.Persistence.MongoDB;
using Crawler.Provider.ZVG;
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

                    services.AddSingleton<IDataProvider, MongoDbDataProvider>();

                    services.AddHostedService<Worker>();

                    services.BuildServiceProvider().GetService<IDataProvider>().Init();
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
                return new List<IMessageSender>();
            });
        }
    }
}
