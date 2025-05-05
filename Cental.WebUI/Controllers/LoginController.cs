using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> _signInManager,UserManager<AppUser> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto model, string? returnUrl)
        {

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false); 
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }

            if (returnUrl !=  null)
            {
              return  Redirect(returnUrl);
            }

            var user = await userManager.FindByNameAsync(model.UserName);
            var userRoles = await userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                if (role == "Admin")
                {
                    return RedirectToAction("Index", "AdminAbout");
                }
                if (role=="Manager")
                {
                    return RedirectToAction("Index", "MySocial",new {area="Manager"});
                }
                if (role == "User")
                {
                    return RedirectToAction("Index", "Default");
                }
            }

            return RedirectToAction("Index","Default");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
