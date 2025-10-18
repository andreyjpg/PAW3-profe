using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface IUserActionService
{
    Task<IEnumerable<UserActionDTO>> GetDataAsync();
    Task<bool> CreateDataAsync(string content);
    Task<bool> UpdateDataAsync(string content);
    Task<bool> DeleteDataAsync(string id);
}

public class UserActionService(IRestProvider restProvider, IConfiguration configuration) : IService<UserActionDTO>, IUserActionService
{
    public async Task<IEnumerable<UserActionDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("APIS", "UserAction");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<UserActionDTO>>(response);
    }

    public async Task<bool> CreateDataAsync(string content)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "UserAction");
        var response = await restProvider.PostAsync(url, content);
        return bool.Parse(response);
    }

    public async Task<bool> UpdateDataAsync(string content)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "UserAction");
        var response = await restProvider.PutAsync(url, content);
        return bool.Parse(response);
    }

    public async Task<bool> DeleteDataAsync(string id)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "UserAction");
        var response = await restProvider.DeleteAsync(url, id);
        return bool.Parse(response);
    }

}
