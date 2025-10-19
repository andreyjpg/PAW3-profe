using PAW3.Minimal.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<MyHttpClient>();

var app = builder.Build();

app.MapProductEndpoints();
app.MapCategoryEndpoints();
app.MapComponentEndpoints();
app.MapInventoryEndpoints();
app.MapRoleEndpoints();
app.MapNotificationEndpoints();
app.MapSupplierEndpoints();
app.MapTaskEndpoints();
app.MapUserActionEndpoints();
app.MapUserEndpoints();
app.MapUserRoleEndpoints();



app.Run();
