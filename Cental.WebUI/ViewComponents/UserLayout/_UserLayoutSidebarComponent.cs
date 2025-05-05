using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UserLayout
{
    public class _UserLayoutSidebarComponent(UserManager<AppUser> userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.nameSurname = string.Join(" ", user.FirstName, user.LastName);
            ViewBag.userImage = user.ImageUrl;

            return View();
        }
    }
}
