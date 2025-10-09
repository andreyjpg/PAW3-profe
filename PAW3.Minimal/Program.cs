var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<MyHttpClient>();

var app = builder.Build();

app.MapGet("/products", async (MyHttpClient apiClient) =>
{
    var data = await apiClient.GetData("ProductApi");
    return Results.Ok(data);

});




app.Run();
