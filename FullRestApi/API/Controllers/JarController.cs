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

        public JarController(IJarService jarService)
        {
            _jarService = jarService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JarModel>> GetJars(UserGetModel model)
        {
            IEnumerable<JarModel> jars = _jarService.GetAll(model);

            if (jars == null  )
            {
                return BadRequest(new { message = "Category element  is null or userID == 0" });
            }


            return Ok(jars);

        }

        [HttpGet("{id}")]
        public ActionResult<JarModel> GetJar(int id, UserGetModel model)
        {
            try
            {
                return Ok(_jarService.GetJar(id, model));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<JarModel> AddJar(JarAddEditModel model)
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
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        public ActionResult DeleteJar(JarDeleteModel model)
        {
            try
            {
                _jarService.Delete(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public ActionResult EditJar(JarAddEditModel model)
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
