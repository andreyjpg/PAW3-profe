using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;
using PAW3.ServiceLocator.Helper;
using PAW3.ServiceLocator.ServiceFactory;
using PAW3.ServiceLocator.Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.ServiceLocator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceLocatorController : ControllerBase
{

    private readonly IServiceFactory _factory;

    public ServiceLocatorController(IServiceFactory factory)
    {
        _factory = factory;
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        dynamic service = _factory.Create(key);
        var data = await service.GetDataAsync();
        return Ok(data);
    }

    [HttpPost("{key}")]
    public async Task<IActionResult> Post(string key, [FromBody] object dto)
    {
        dynamic service = _factory.Create(key);
        var stringJson = JsonSerializer.Serialize(dto);
        var created = await service.CreateDataAsync(stringJson);
        return Ok(created);
    }

    [HttpDelete("{key}/{id}")]
    public async Task<IActionResult> Delete(string key, string id)
    {
        dynamic service = _factory.Create(key);
        var data = await service.DeleteDataAsync(id);
        return Ok(data);
    }

    [HttpPut("{key}")]
    public async Task<IActionResult> Update(string key, [FromBody] object dto)
    {
        dynamic service = _factory.Create(key);
        var stringJson = JsonSerializer.Serialize(dto);
        var updated = await service.UpdateDataAsync(stringJson);
        return Ok(updated);
    }


    //// GET api/<ServiceLocatorController>/5
    //[HttpGet("{name}")]
    //public async Task<IEnumerable<object>> Get(string name)
    //{
    //    if (ServiceResolvers.TryGetValue(name.ToLower(), out var resolver))
    //        return await resolver();

    //    return [];
    //}

    //// POST api/<ServiceLocatorController>
    //[HttpPost]
    //public async Task<bool> Post([FromBody] object T)
    //{
    //    if(ServiceResolvers.TryGetValue(T.ToString(), out var resolver))
    //}

    //// PUT api/<ServiceLocatorController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] object T)
    //{

    //}

    //// DELETE api/<ServiceLocatorController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
