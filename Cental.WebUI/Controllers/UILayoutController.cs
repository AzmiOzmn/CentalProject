using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
