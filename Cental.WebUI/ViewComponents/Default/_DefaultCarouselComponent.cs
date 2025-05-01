using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCarouselComponent(IBannerService bannerService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = bannerService.TGetAll();
            return View(values);
        }
    }
}
