using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using Task = PAW3.Data.Models.Task;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskApiController(ITaskBusiness taskBusiness) : ControllerBase
    {
        // GET: api/<TaskApiController>
        [HttpGet]
        public async Task<IEnumerable<Task>> Get()
        {
            return await taskBusiness.GetTasks(id: null);
        }

        // GET api/<TaskApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Task>> Get(int id)
        {
            return await taskBusiness.GetTasks(id);
        }

        // POST api/<TaskApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Task task)
        {
            return await taskBusiness.UpsertTaskAsync(task);
        }

        // PUT api/<TaskApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Task value)
        {
            return await taskBusiness.UpsertTaskAsync(value);
        }

        // DELETE api/<TaskApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await taskBusiness.DeleteTaskAsync(id);
        }
    }
}
