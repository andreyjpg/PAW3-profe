using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ProyectoMinimalApi.Endpoints;

public static class CrudEndpointMapper
{
    public static void MapCrudEndpoints<T>(
        this WebApplication app,
        string routeBase,
        string apiEndpoint)
        where T : class
    {
        // GET all
        app.MapGet($"{routeBase}", async (MyHttpClient client) =>
        {
            var data = await client.GetData<T>(apiEndpoint);
            return Results.Ok(data);
        });

        // POST
        app.MapPost($"{routeBase}", async (T model, MyHttpClient client) =>
        {
            var json = JsonSerializer.Serialize(model);
            var created = await client.CreateData(apiEndpoint, json);
            return Results.Created($"{routeBase}/{{created?.Id}}", created);
        });

        // PUT
        app.MapPut($"{routeBase}/{{id:int}}", async (int id, T model, MyHttpClient client) =>
        {
            var json = JsonSerializer.Serialize(model);
            var success = await client.PutData(apiEndpoint, json);
            return success ? Results.NoContent() : Results.NotFound();
        });

        // DELETE
        app.MapDelete($"{routeBase}/{{id:int}}", async (int id, MyHttpClient client) =>
        {
            var success = await client.DeleteData($"{apiEndpoint}/{id}");
            return success ? Results.NoContent() : Results.NotFound();
        });
    }
}
