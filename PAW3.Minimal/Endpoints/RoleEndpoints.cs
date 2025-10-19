using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class RoleEndpoints
    {
        public static void MapRoleEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<Role>("/role", "RoleApi");
        }
    }
}
