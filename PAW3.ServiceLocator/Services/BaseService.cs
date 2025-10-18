using PAW3.Architecture;
using PAW3.Models.DTOs;
using PAW3.Architecture.Providers;
using PAW3.ServiceLocator.Services.Contracts;

namespace PAW3.ServiceLocator.Services.Base;

public abstract class BaseService<TDto> : IService<TDto> where TDto : class
{
    private readonly IConfiguration _configuration;
    private readonly string _apiKey;

    protected BaseService(IConfiguration configuration, string apiKey)
    {
        _configuration = configuration;
        _apiKey = apiKey;
    }

    protected string GetApiUrl()
        => _configuration.GetStringFromAppSettings("APIS", _apiKey);

    public async Task<IEnumerable<TDto>> GetDataAsync()
    {
        var operation = new GetOperation();
        var response = await operation.ExecuteAsync(GetApiUrl(), null);
        return await JsonProvider.DeserializeAsync<IEnumerable<TDto>>(response);
    }

    public async Task<bool> CreateDataAsync(string content)
    {
        var operation = new PostOperation();
        var response = await operation.ExecuteAsync(GetApiUrl(), content);
        return bool.Parse(response);
    }

    public async Task<bool> UpdateDataAsync(string content)
    {
        var operation = new UpdateOperation();
        var response = await operation.ExecuteAsync(GetApiUrl(), content);
        return bool.Parse(response);
    }

    public async Task<bool> DeleteDataAsync(string id)
    {
        var operation = new DeleteOperation();
        var response = await operation.ExecuteAsync($"{GetApiUrl()}/{id}");
        return bool.Parse(response);
    }
}
