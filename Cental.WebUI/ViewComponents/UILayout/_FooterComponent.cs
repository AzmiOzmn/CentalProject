using Cental.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _FooterComponent(CentalContext context) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = context.FooterContacts.ToList();
            return View(values);
        }
    }
}
