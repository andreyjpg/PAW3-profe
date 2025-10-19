using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class InventoryEndpoints
    {
        public static void MapInventoryEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<Inventory>("/inventory", "InventoryApi");
        }
    }
}
