using Microsoft.Extensions.Configuration;
using PAW3.Architecture;
using PAW3.Architecture.Providers;

namespace PAW3.ServiceLocator.Services
{
    public class DogDataService : IDogDataService
    {
        private readonly IConfiguration _configuration;

        public DogDataService( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetDataAsync()
        {
            var url = _configuration.GetStringFromAppSettings("APIS", "Dogs");
            var operation = new GetOperation();
            var response = await operation.ExecuteAsync(url, null);
            return await JsonProvider.DeserializeAsync<string>(response);
        }
    }

    public interface IDogDataService
    {
        Task<string> GetDataAsync();
    }
}
