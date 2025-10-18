using PAW3.Architecture.Helpers;

public abstract class RestOperation
{
    public async Task<string> ExecuteAsync(string endpoint, string? content = null)
    {
        try
        {
            using var client = RestProviderHelpers.CreateHttpClient(endpoint);
            var response = await SendRequest(client, endpoint, content);
            return await RestProviderHelpers.GetResponse(response);
        }
        catch (Exception ex)
        {
            throw RestProviderHelpers.ThrowError(endpoint, ex);
        }
    }

    protected abstract Task<HttpResponseMessage> SendRequest(HttpClient client, string endpoint, string? content);
}

public class PostOperation : RestOperation
{
    protected override Task<HttpResponseMessage> SendRequest(HttpClient client, string endpoint, string? content)
        => client.PostAsync(endpoint, RestProviderHelpers.CreateContent(content!));
}

public class UpdateOperation : RestOperation
{
    protected override Task<HttpResponseMessage> SendRequest(HttpClient client, string endpoint, string? content)
        => client.PutAsync(endpoint, RestProviderHelpers.CreateContent(content!));
}

public class DeleteOperation : RestOperation
{
    protected override Task<HttpResponseMessage> SendRequest(HttpClient client, string endpoint, string? content)
        => client.DeleteAsync(endpoint);
}

public class GetOperation : RestOperation
{
    protected override Task<HttpResponseMessage> SendRequest(HttpClient client, string endpoint, string? content)
        => client.GetAsync(content);
}