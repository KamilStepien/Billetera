using FullRESTAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullRESTAPI.Models.ShoppingListElements;
using FullRESTAPI.Models.Users;

namespace FullRESTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListElementController : Controller
    {
        public IShoppingListElementService _shoppingListElementService;

        public ShoppingListElementController(IShoppingListElementService shoppingListElementService)
        {
            _shoppingListElementService = shoppingListElementService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShoppingListElementModel>> GetShoppingListElement(UserGetModel model)
        {
            IEnumerable<ShoppingListElementModel> shoppingListElements = _shoppingListElementService.GetAll(model);

            if (shoppingListElements == null)
            {
                return BadRequest(new { message = "Category element  is null or userID == 0" });
            }


            return Ok(shoppingListElements);

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteShoppingListElement(int  id)
        {
            try
            {
                _shoppingListElementService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<ShoppingListElementModel> AddShoppingListElement(ShopingListElementAddModel model)
        {
            try
            {
                return Ok(_shoppingListElementService.Add(model));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
