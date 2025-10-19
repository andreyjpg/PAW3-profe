using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class NotificationEndpoints
    {
        public static void MapNotificationEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<Notification>("/notification", "NotificationApi");
        }
    }
}
