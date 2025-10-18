using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.ServiceLocator.Helper;
using System;

namespace PAW3.Mvc.ServiceLocator;

public interface IServiceLocatorService
{
    Task<IEnumerable<T>> GetDataAsync<T>(string name);
    Task<bool> UpdateDataAsync(string name, string content);
    Task<bool> DeleteDataAsync(string name, string contentId);
    Task<bool> SaveDataAsync(string name, string content);

}

public class ServiceLocatorService( IServiceMapper serviceMapper) : IServiceLocatorService
{
    private string url = "https://localhost:7130/api/ServiceLocator";
    public async Task<IEnumerable<T>> GetDataAsync<T>(string name)
    {
        var operation = new GetOperation();
        var response = await operation.ExecuteAsync($"{url}/{name}", null);
        return await JsonProvider.DeserializeAsync<IEnumerable<T>>(response);
    }

    public async Task<bool> UpdateDataAsync(string name, string content)
    {
        var operation = new UpdateOperation();
        var response = await operation.ExecuteAsync($"{url}/{name}", content);
        return response.Length > 0;
    }

    public async Task<bool> DeleteDataAsync(string name, string contentId )
    {
        var operation = new DeleteOperation();
        var response = await operation.ExecuteAsync($"{url}/{name}/{contentId}");
        return response.Length > 0;
    }

    public async Task<bool> SaveDataAsync(string name, string content)
    {
        var operation = new PostOperation();
        var response = await operation.ExecuteAsync($"{url}/{name}", content);
        return response.Length > 0;
    }
}
