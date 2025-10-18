using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.ServiceLocator.Helper;

namespace PAW3.Mvc.ServiceLocator;

public interface IServiceLocatorService
{
    Task<IEnumerable<T>> GetDataAsync<T>(string name);
    Task<bool> UpdateDataAsync(string name, string content);
    Task<bool> DeleteDataAsync(string name, string contentId);
    Task<bool> SaveDataAsync(string name, string content);

}

public class ServiceLocatorService(IRestProvider restProvider, IServiceMapper serviceMapper) : IServiceLocatorService
{
    public async Task<IEnumerable<T>> GetDataAsync<T>(string name)
    {
        var response = await restProvider.GetAsync("https://localhost:7130/api/ServiceLocator/", name);
        return await JsonProvider.DeserializeAsync<IEnumerable<T>>(response);
    }

    public async Task<bool> UpdateDataAsync(string name, string content)
    {
        var response = await restProvider.PutAsync($"https://localhost:7130/api/ServiceLocator/{name}", content);
        Console.WriteLine(response);
        return response.Length > 0;
    }

    public async Task<bool> DeleteDataAsync(string name, string contentId )
    {
        var response = await restProvider.DeleteAsync($"https://localhost:7130/api/ServiceLocator/{name}", contentId);
        Console.WriteLine(response);
        return response.Length > 0;
    }

    public async Task<bool> SaveDataAsync(string name, string content)
    {
        var response = await restProvider.PostAsync($"https://localhost:7130/api/ServiceLocator/{name}", content);
        Console.WriteLine(response);
        return response.Length > 0;
    }
}
