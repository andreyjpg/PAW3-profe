using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetDataAsync();
    Task<bool> CreateDataAsync(string content);
    Task<bool> UpdateDataAsync(string content);
    Task<bool> DeleteDataAsync(string id);
}

public class ProductService(IRestProvider restProvider, IConfiguration configuration) : IService<ProductDTO>, IProductService
{
    public async Task<IEnumerable<ProductDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Product");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<ProductDTO>>(response);
    }

    public async Task<bool> CreateDataAsync(string content)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Product");
        var response = await restProvider.PostAsync(url, content);
        return bool.Parse(response);
    }

    public async Task<bool> UpdateDataAsync(string content)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Product");
        var response = await restProvider.PutAsync(url, content);
        return bool.Parse(response);
    }

    public async Task<bool> DeleteDataAsync(string id)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Product");
        var response = await restProvider.DeleteAsync(url, id);
        return bool.Parse(response);
    }

}
