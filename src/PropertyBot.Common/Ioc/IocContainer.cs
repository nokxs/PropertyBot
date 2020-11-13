using System;
using Microsoft.Extensions.DependencyInjection;

namespace PropertyBot.Common.Ioc
{
    public class IocContainer : IIocContainer
    {
        private readonly IServiceCollection _serviceCollection;

        public IocContainer(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void AddSingleton<TService>() where TService : class
        {
            _serviceCollection.AddSingleton<TService>();
        }

        public void AddSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            _serviceCollection.AddSingleton<TService, TImplementation>();
        }

        public void AddSingleton<TService>(TService service) where TService : class
        {
            _serviceCollection.AddSingleton(service);
        }
    }
}
