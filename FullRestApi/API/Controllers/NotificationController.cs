using FullRESTAPI.Models.Notifications;
using FullRESTAPI.Models.Users;
using FullRESTAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : Controller
    {
        private INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("user/{id}")]
        public ActionResult<IEnumerable<NotificationModel>> GetNotification(int  id)
        {
            IEnumerable<NotificationModel> notifications = _notificationService.GetAll(id);

            if (notifications == null)
            {
                return BadRequest(new { message = "Category element  is null or userID == 0" });
            }


            return Ok(notifications);

        }

        

        [HttpPost("deactive-notyfication/{id}")]
        public IActionResult DeactiveNotification(int id)
        {
            try
            {
                _notificationService.DeactiveNotification(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
