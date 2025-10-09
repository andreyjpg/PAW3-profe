using System.Net.Http;
using System.Threading.Tasks;


public class MyHttpClient
{
    private readonly HttpClient _httpClient;

    public MyHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7180/api/");
    }

    public async Task<ICollection<Product>> GetData(string endpoint)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ICollection<Product>>();
        
    }

    public static implicit operator HttpClient(MyHttpClient v)
    {
        throw new NotImplementedException();
    }
}

