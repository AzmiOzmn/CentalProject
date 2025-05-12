using AutoMapper;
using Cental.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminFooterController(CentalContext context ) : Controller
    {
        public IActionResult Index()
        {
            var result = context.FooterContacts.ToList();
            return View(result);
        }
    }
}
