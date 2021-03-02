using FullRESTAPI.Models.Jars;
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
    public class JarController : Controller
    {

        IJarService _jarService;
        INotificationService _notificationService;

        public JarController(IJarService jarService, INotificationService notificationService)
        {
            _jarService = jarService;
            _notificationService = notificationService;
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<JarModel>> GetJars(int userId)
        {
            IEnumerable<JarModel> jars = _jarService.GetAll(userId).Where(x => x.State == Models.EFModels.JarState.inProgress);

            if (jars == null  )
            {
                return BadRequest(new { message = "Category element  is null or userID == 0" });
            }


            return Ok(jars);

        }

        [HttpGet("{id}")]
        public ActionResult<JarModel> GetJar(int id)
        {
            try
            {
                return Ok(_jarService.GetJar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<JarModel> AddJar(JarAddModel model)
        {
            try
            {
                return Ok(_jarService.Add(model));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("end")]
        public IActionResult EndJar(JarEndModel model)
        {
            try
            {
                _jarService.EndJar(model);
                var jarCount = _jarService.GetAll(model.UserId).Where(x=>x.State == Models.EFModels.JarState.Reached).Count();

                if (jarCount == 1)
                    _notificationService.ActiveNotyfication(model.UserId, 2);
                if (jarCount == 5)
                    _notificationService.ActiveNotyfication(model.UserId, 3);
                if (jarCount == 10)
                    _notificationService.ActiveNotyfication(model.UserId, 4);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("add-money")]
        public IActionResult AddMoneyToJar(JarAddMoneyModel model)
        {
            try
            {
                _jarService.AddMoneyToJar(model);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJar(int id)
        {
            try
            {
                _jarService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public ActionResult EditJar(JarEditModel model)
        {
            try
            {
                return Ok(_jarService.Edit(model));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
