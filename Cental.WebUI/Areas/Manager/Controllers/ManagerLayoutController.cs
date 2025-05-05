using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ManagerLayoutController() : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
