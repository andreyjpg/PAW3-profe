using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using UserAction = PAW3.Data.Models.UserAction;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/useraction")]
    [ApiController]
    public class UserActionApiController : ControllerBase
    {
        private readonly IUserActionBusiness userActionBusiness;

        public UserActionApiController(IUserActionBusiness userActionBusiness)
        {
            this.userActionBusiness = userActionBusiness;
        }

        // GET api/useraction
        [HttpGet]
        public async Task<IEnumerable<UserAction>> Get()
            => await userActionBusiness.GetUserActions(null);

        // GET api/useraction/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<UserAction>> Get(int id)
            => await userActionBusiness.GetUserActions(id);

        // POST api/useraction
        [HttpPost]
        public async Task<bool> Post([FromBody] UserAction value)
            => await userActionBusiness.UpsertUserActionAsync(value);

        // PUT api/useraction
        [HttpPut]
        public async Task<bool> Put([FromBody] UserAction value)
            => await userActionBusiness.UpsertUserActionAsync(value);

        // DELETE api/useraction/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
            => await userActionBusiness.DeleteUserActionAsync(id);
    }
}
