using PAW3.Architecture;
using PAW3.Architecture.Providers;

namespace PAW3.ServiceLocator.Services;

public class TempDataService : ITempDataService
{
    private readonly IConfiguration _configuration;

    public TempDataService( IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<string>> GetDataAsync()
    {
        var url = _configuration.GetStringFromAppSettings("APIS", "TempData");
        var operation = new GetOperation();
        var response = await operation.ExecuteAsync(url, null);
        return await JsonProvider.DeserializeAsync<IEnumerable<string>>(response);
    }
}

public interface ITempDataService
{
    Task<IEnumerable<string>> GetDataAsync();
}
