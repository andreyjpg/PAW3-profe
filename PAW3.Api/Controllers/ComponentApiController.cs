using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using Component = PAW3.Data.Models.Component;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentApiController(IComponentBusiness componentBusiness) : ControllerBase
    {
        // GET: api/<ComponentApiController>
        [HttpGet]
        public async Task<IEnumerable<Component>> Get()
        {
            return await componentBusiness.GetComponents(id: null);
        }

        // GET api/<ComponentApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Component>> Get(int id)
        {
            return await componentBusiness.GetComponents(id);
        }

        // POST api/<ComponentApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Component component)
        {
            return await componentBusiness.UpsertComponentAsync(component);
        }

        // PUT api/<ComponentApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Component value)
        {
            return await componentBusiness.UpsertComponentAsync(value);
        }

        // DELETE api/<ComponentApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await componentBusiness.DeleteComponentAsync(id);
        }
    }
}
