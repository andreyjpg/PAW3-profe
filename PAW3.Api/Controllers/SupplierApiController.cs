using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using Supplier = PAW3.Data.Models.Supplier;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierApiController(ISupplierBusiness supplierBusiness) : ControllerBase
    {
        // GET: api/<SupplierApiController>
        [HttpGet]
        public async Task<IEnumerable<Supplier>> Get()
        {
            return await supplierBusiness.GetSuppliers(id: null);
        }

        // GET api/<SupplierApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Supplier>> Get(int id)
        {
            return await supplierBusiness.GetSuppliers(id);
        }

        // POST api/<SupplierApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Supplier supplier)
        {
            return await supplierBusiness.UpsertSupplierAsync(supplier);
        }

        // PUT api/<SupplierApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Supplier value)
        {
            return await supplierBusiness.UpsertSupplierAsync(value);
        }

        // DELETE api/<SupplierApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await supplierBusiness.DeleteSupplierAsync(id);
        }
    }
}
