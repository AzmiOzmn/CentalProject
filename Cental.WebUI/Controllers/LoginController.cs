using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class LoginController(SignInManager<AppUser> _signInManager) : Controller
    { 
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserLoginDto model)
        {
            var values = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false); 
            if (!values.Succeeded)
            {
              ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
              return View(model);
            }
            
            return RedirectToAction("Index", "AdminAbout");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Default");
        }
    }
}
