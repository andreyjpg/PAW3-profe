using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class ComponentEndpoints
    {
        public static void MapComponentEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<Component>("/component", "ComponentApi");
        }
    }
}
