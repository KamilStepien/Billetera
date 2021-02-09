using FullRESTAPI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullRESTAPI.Models;
using System.Transactions;
using FullRESTAPI.Services;
using FullRESTAPI.Models.Categories;
using FullRESTAPI.Models.Users;

namespace FullRESTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategorieController : Controller
    {

        private ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<CategorieModel>> GetCategories(int userId)
        {
            try
            {
                IEnumerable<CategorieModel> categories = _categorieService.GetAll(userId);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult<CategorieModel> AddCategory(CategorieAddModel model)
        {
            try
            {
                return Ok(_categorieService.Add(model));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                _categorieService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



    }
}
