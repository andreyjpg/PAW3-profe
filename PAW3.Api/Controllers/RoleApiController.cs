using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using Role = PAW3.Data.Models.Role;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleApiController(IRoleBusiness RoleBusiness) : ControllerBase
    {
        // GET: api/<RoleApiController>
        [HttpGet]
        public async Task<IEnumerable<Role>> Get()
        {
            return await RoleBusiness.GetRoles(id: null);
        }

        // GET api/<RoleApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Role>> Get(int id)
        {
            return await RoleBusiness.GetRoles(id);
        }

        // POST api/<RoleApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Role role)
        {
            return await RoleBusiness.UpsertRoleAsync(role);
        }

        // PUT api/<RoleApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Role value)
        {
            return await RoleBusiness.UpsertRoleAsync(value);
        }

        // DELETE api/<RoleApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await RoleBusiness.DeleteRoleAsync(id);
        }
    }
}
