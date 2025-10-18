using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using UserAction = PAW3.Data.Models.UserAction;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionApiController(IUserActionBusiness userActionBusiness) : ControllerBase
    {
        // GET: api/<UserActionApiController>
        [HttpGet]
        public async Task<IEnumerable<UserAction>> Get()
        {
            return await userActionBusiness.GetUserActions(id: null);
        }

        // GET api/<UserActionApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<UserAction>> Get(int id)
        {
            return await userActionBusiness.GetUserActions(id);
        }

        // POST api/<UserActionApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] UserAction product)
        {
            return await userActionBusiness.UpsertUserActionAsync(product);
        }

        // PUT api/<UserActionApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] UserAction value)
        {
            return await userActionBusiness.UpsertUserActionAsync(value);
        }

        // DELETE api/<UserActionApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await userActionBusiness.DeleteUserActionAsync(id);
        }
    }
}
