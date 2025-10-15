using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using Category = PAW3.Data.Models.Category;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController(ICategoryBusiness categoryBusiness) : ControllerBase
    {
        // GET: api/<CategoryApiController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await categoryBusiness.GetCategorys(id: null);
        }

        // GET api/<CategoryApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Category>> Get(int id)
        {
            return await categoryBusiness.GetCategorys(id);
        }

        // POST api/<CategoryApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Category category)
        {
            return await categoryBusiness.UpsertCategoryAsync(category);
        }

        // PUT api/<CategoryApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Category value)
        {
            return await categoryBusiness.UpsertCategoryAsync(value);
        }

        // DELETE api/<CategoryApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await categoryBusiness.DeleteCategoryAsync(id);
        }
    }
}
