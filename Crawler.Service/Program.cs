using System.Collections.Generic;
using Crawler.Interface;
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
                    services.AddSingleton<IEnumerable<IPropertyProvider>>(serviceProvider =>
                    {
                        return new IPropertyProvider[]
                        {
                            ZvgProviderFactory.CreateClient()
                        };
                    });

                    services.AddHostedService<Worker>();
                });
    }
}
