using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using UserRole = PAW3.Data.Models.UserRole;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleApiController(IUserRoleBusiness userRoleBusiness) : ControllerBase
    {
        // GET: api/<UserRoleApiController>
        [HttpGet]
        public async Task<IEnumerable<UserRole>> Get()
        {
            return await userRoleBusiness.GetUserRoles(id: null);
        }

        // GET api/<UserRoleApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<UserRole>> Get(int id)
        {
            return await userRoleBusiness.GetUserRoles(id);
        }

        // POST api/<UserRoleApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] UserRole product)
        {
            return await userRoleBusiness.UpsertUserRoleAsync(product);
        }

        // PUT api/<UserRoleApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] UserRole value)
        {
            return await userRoleBusiness.UpsertUserRoleAsync(value);
        }

        // DELETE api/<UserRoleApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await userRoleBusiness.DeleteUserRoleAsync(id);
        }
    }
}
