using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<Product>("/product", "ProductApi");
        }
    }
}
