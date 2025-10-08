using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentApiController(IComponentBusiness ComponentBusiness) : ControllerBase
    {
        // GET: api/<ComponentApiController>
        [HttpGet]
        public async Task<IEnumerable<Component>> Get()
        {
            return await ComponentBusiness.GetComponents(id: null);
        }

        // GET api/<ComponentApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComponentApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ComponentApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComponentApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
