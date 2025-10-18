using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using Inventory = PAW3.Data.Models.Inventory;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryApiController(IInventoryBusiness inventoryBusiness) : ControllerBase
    {
        // GET: api/<InventoryApiController>
        [HttpGet]
        public async Task<IEnumerable<Inventory>> Get()
        {
            return await inventoryBusiness.GetInventorys(id: null);
        }

        // GET api/<InventoryApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Inventory>> Get(int id)
        {
            return await inventoryBusiness.GetInventorys(id);
        }

        // POST api/<InventoryApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Inventory inventory)
        {
            return await inventoryBusiness.UpsertInventoryAsync(inventory);
        }

        // PUT api/<InventoryApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Inventory value)
        {
            return await inventoryBusiness.UpsertInventoryAsync(value);
        }

        // DELETE api/<InventoryApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await inventoryBusiness.DeleteInventoryAsync(id);
        }
    }
}
