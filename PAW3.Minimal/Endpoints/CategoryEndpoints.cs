using ProyectoMinimalApi.Endpoints;

namespace PAW3.Minimal.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            app.MapCrudEndpoints<Category>("/category", "CategoryApi");
        }
    }
}
