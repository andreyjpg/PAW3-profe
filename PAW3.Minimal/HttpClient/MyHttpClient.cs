using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class MyHttpClient
{
    private readonly HttpClient _httpClient;

    public MyHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7180/api/");
    }

    public async Task<ICollection<T>> GetData<T>(string endpoint)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ICollection<T>>();
        
    }

    public async Task<bool> CreateData(string endpoint, string content)
    {
        HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync(endpoint, httpContent);
        response.EnsureSuccessStatusCode();
        return response.IsSuccessStatusCode;

    }

    public async Task<bool> PutData(string endpoint, string content)
    {
        HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PutAsync(endpoint, new StringContent(content));
        response.EnsureSuccessStatusCode();
        return response.IsSuccessStatusCode;

    }

    public async Task<bool> DeleteData(string endpoint)
    {
        HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);
        response.EnsureSuccessStatusCode();
        return response.IsSuccessStatusCode;

    }

    public static implicit operator HttpClient(MyHttpClient v)
    {
        throw new NotImplementedException();
    }
}

