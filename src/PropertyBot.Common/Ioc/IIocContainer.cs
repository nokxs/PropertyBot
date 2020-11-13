namespace PropertyBot.Common.Ioc
{
    public interface IIocContainer
    {
        void AddSingleton<TService>() where TService : class;
        void AddSingleton<TService>(TService service) where TService : class;
    }
}