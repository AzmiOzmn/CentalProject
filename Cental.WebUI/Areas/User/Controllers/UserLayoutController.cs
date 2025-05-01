using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    public class UserLayoutController : Controller
    {
        [Area("User")]
        [Authorize(Roles = "User")]
        public IActionResult Layout()
        {
            return View();
        }
    }
}
