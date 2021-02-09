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

        [HttpGet]
        public ActionResult<IEnumerable<NotificationModel>> GetNotification(UserGetModel model)
        {
            IEnumerable<NotificationModel> notifications = _notificationService.GetAll(model);

            if (notifications == null)
            {
                return BadRequest(new { message = "Category element  is null or userID == 0" });
            }


            return Ok(notifications);

        }

        [HttpPost("active-notyfication")]
        public IActionResult ActiveNotyfication(ActiveNotificationModel model)
        {
            try
            {
                _notificationService.ActiveNotyfication(model);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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
