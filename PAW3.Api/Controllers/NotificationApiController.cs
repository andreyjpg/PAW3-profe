using Microsoft.AspNetCore.Mvc;
using PAW3.Core.BusinessLogic;
using Notification = PAW3.Data.Models.Notification;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationApiController(INotificationBusiness notificationBusiness) : ControllerBase
    {
        // GET: api/<NotificationApiController>
        [HttpGet]
        public async Task<IEnumerable<Notification>> Get()
        {
            return await notificationBusiness.GetNotifications(id: null);
        }

        // GET api/<NotificationApiController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Notification>> Get(int id)
        {
            return await notificationBusiness.GetNotifications(id);
        }

        // POST api/<NotificationApiController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Notification notification)
        {
            return await notificationBusiness.UpsertNotificationAsync(notification);
        }

        // PUT api/<NotificationApiController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Notification value)
        {
            return await notificationBusiness.UpsertNotificationAsync(value);
        }

        // DELETE api/<NotificationApiController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await notificationBusiness.DeleteNotificationAsync(id);
        }
    }
}
