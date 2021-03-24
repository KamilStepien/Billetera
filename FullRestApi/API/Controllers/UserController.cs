using FullRESTAPI.Models.Users;
using FullRESTAPI.Models.Categories;
using FullRESTAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace FullRESTAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private IUserService _userService;
        private INotificationService _notificationService;
        private ICategorieService _categorieService;

        public UserController (IUserService userService, INotificationService notificationService , ICategorieService categorieService)
        {
            _userService = userService;
            _notificationService = notificationService;
            _categorieService = categorieService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {

            
            var user = new UserModel { Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };

            try
            {
                var userReturn = _userService.Create(user, model.Password);
                _notificationService.ActiveNotyfication(userReturn.Id,1);
                _categorieService.Add(new CategorieAddModel { Name = "home", UserId = userReturn.Id });
                _categorieService.Add(new CategorieAddModel { Name = "expenses", UserId = userReturn.Id });
                _categorieService.Add(new CategorieAddModel { Name = "income", UserId = userReturn.Id });
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

         
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] UserEditModel model)
        {
            try
            {
                _userService.Edit(model);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
