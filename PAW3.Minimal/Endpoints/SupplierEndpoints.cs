using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class SupplierEndpoints
    {
        public static void MapSupplierEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<Supplier>("/supplier", "SupplierApi");
        }
    }
}
