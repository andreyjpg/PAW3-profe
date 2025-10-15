using PAW3.Architecture;
using PAW3.Architecture.Providers;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services;

public interface INotificationService
{
    Task<IEnumerable<NotificationDTO>> GetDataAsync();
    Task<bool> CreateDataAsync(string content);
    Task<bool> UpdateDataAsync(string id, string content);
    Task<bool> DeleteDataAsync(string id);
}

public class NotificationService(IRestProvider restProvider, IConfiguration configuration) : IService<NotificationDTO>, INotificationService
{
    public async Task<IEnumerable<NotificationDTO>> GetDataAsync()
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Notification");
        var response = await restProvider.GetAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<NotificationDTO>>(response);
    }

    public async Task<bool> CreateDataAsync(string content)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Notification");
        var response = await restProvider.PostAsync(url, content);
        return bool.Parse(response);
    }

    public async Task<bool> UpdateDataAsync(string id, string content)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Notification");
        var response = await restProvider.PutAsync(url, id, content);
        return bool.Parse(response);
    }

    public async Task<bool> DeleteDataAsync(string id)
    {
        var url = configuration.GetStringFromAppSettings("APIS", "Notification");
        var response = await restProvider.DeleteAsync(url, id);
        return bool.Parse(response);
    }

}
