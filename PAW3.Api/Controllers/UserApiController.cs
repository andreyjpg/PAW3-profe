using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using User = PAW3.Data.Models.User;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController(IUserBusiness userBusiness) : ControllerBase
    {
        // GET: api/<UserApiController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userBusiness.GetUsers(id: null);
        }

        // GET api/<UserApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<User>> Get(int id)
        {
            return await userBusiness.GetUsers(id);
        }

        // POST api/<UserApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] User product)
        {
            return await userBusiness.UpsertUserAsync(product);
        }

        // PUT api/<UserApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] User value)
        {
            return await userBusiness.UpsertUserAsync(value);
        }

        // DELETE api/<UserApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await userBusiness.DeleteUserAsync(id);
        }
    }
}
