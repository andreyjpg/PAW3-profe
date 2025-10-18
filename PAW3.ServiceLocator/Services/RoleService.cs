using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface IRoleService
{
    Task<IEnumerable<RoleDTO>> GetDataAsync();
    Task<bool> CreateDataAsync(string content);
    Task<bool> UpdateDataAsync(string content);
    Task<bool> DeleteDataAsync(string id);
}

public class RoleService(IRestProvider restProvider, IConfiguration configuration) : IService<RoleDTO>, IRoleService
{
    public async Task<IEnumerable<RoleDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Role");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<RoleDTO>>(response);
    }

    public async Task<bool> CreateDataAsync(string content)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Role");
        var response = await restProvider.PostAsync(url, content);
        return bool.Parse(response);
    }

    public async Task<bool> UpdateDataAsync(string content)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Role");
        var response = await restProvider.PutAsync(url, content);
        return bool.Parse(response);
    }

    public async Task<bool> DeleteDataAsync(string id)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Role");
        var response = await restProvider.DeleteAsync(url, id);
        return bool.Parse(response);
    }

}
