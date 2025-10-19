using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class UserActionEndpoints
    {
        public static void MapUserActionEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<UserAction>("/userAction", "UserActionApi");
        }
    }
}
