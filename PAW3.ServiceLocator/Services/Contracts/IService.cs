namespace PAW3.ServiceLocator.Services.Contracts;

public interface IService<T>
{
    Task<IEnumerable<T>> GetDataAsync();
    Task<bool> CreateDataAsync(string content);
    Task<bool> UpdateDataAsync(string content);
    Task<bool> DeleteDataAsync(string id);
}