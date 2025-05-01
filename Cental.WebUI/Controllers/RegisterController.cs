using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController(UserManager<AppUser> _userManager, IMapper _mapper) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SignUp(UserRegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);

            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
            await _userManager.AddToRoleAsync(user, "User");

            return RedirectToAction("Index", "Login");

           
        }
    }
}
