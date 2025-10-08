using PAW3.Architecture;
using PAW3.Models.DTOs;
using PAW3.Mvc.ServiceLocator;
using PAW3.ServiceLocator.Helper;
using PAW3.ServiceLocator.Services;
using PAW3.ServiceLocator.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRestProvider, RestProvider>();
builder.Services.AddScoped<IDogDataService, DogDataService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IServiceLocatorService, ServiceLocatorService>();
builder.Services.AddScoped<IServiceMapper, ServiceMapper>();
builder.Services.AddScoped<IService<ProductDTO>, ProductService>();
builder.Services.AddScoped<IService<CategoryDTO>, CategoryService>();
builder.Services.AddScoped<IService<ComponentDTO>, ComponentService>();
builder.Services.AddScoped<IService<NotificationDTO>, NotificationService>();
builder.Services.AddScoped<IService<InventoryDTO>, InventoryService>();
builder.Services.AddScoped<IService<RoleDTO>, RoleService>();
builder.Services.AddScoped<IService<SupplierDTO>, SupplierService>();
builder.Services.AddScoped<IService<TaskDTO>, TaskService>();
builder.Services.AddScoped<IService<UserActionDTO>, UserActionService>();
builder.Services.AddScoped<IService<UserDTO>, UserService>();
builder.Services.AddScoped<IService<UserRoleDTO>, UserRoleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
