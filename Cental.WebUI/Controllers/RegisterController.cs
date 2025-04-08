using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class RegisterController(UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public IActionResult SignUp(UserRegisterDto model)
        {
            return View();
        }
    }
}
