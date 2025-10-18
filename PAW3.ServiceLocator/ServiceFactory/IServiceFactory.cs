namespace PAW3.ServiceLocator.ServiceFactory
{
    public interface IServiceFactory
    {
        object Create(string key);
    }
}
