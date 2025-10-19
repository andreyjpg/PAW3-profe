using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class UserRoleEndpoints
    {
        public static void MapUserRoleEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<UserRole>("/userRole", "UserRoleApi");
        }
    }
}
