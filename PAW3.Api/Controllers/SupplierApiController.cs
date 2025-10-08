using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using PAW3.Data.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierApiController(ISupplierBusiness SupplierBusiness) : ControllerBase
    {
        // GET: api/<SupplierApiController>
        [HttpGet]
        public async Task<IEnumerable<Supplier>> Get()
        {
            return await SupplierBusiness.GetSuppliers(id: null);
        }

        // GET api/<SupplierApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SupplierApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
