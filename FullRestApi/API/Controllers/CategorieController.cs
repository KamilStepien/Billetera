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

        [HttpGet]
        public ActionResult<IEnumerable<CategorieModel>> GetCategories(UserGetModel model)
        {
            IEnumerable<CategorieModel> categories = _categorieService.GetAll(model);

            if (categories == null)
            {
                return BadRequest(new { message = "Category element  is null or userID == 0" });
            }

            return Ok(categories);

        }

        [HttpPost]
        public ActionResult<CategorieModel> AddCategory (CategorieModel model)
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

        [HttpDelete]
        public ActionResult DeleteCategory(CategorieDeleteModel model)
        {
            try
            {
                _categorieService.Delete(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



    }
}
