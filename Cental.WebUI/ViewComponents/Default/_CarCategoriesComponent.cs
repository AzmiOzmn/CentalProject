using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _CarCategoriesComponent : ViewComponent
    {
        private readonly ICarService _carService;

        public _CarCategoriesComponent(ICarService carService)
        {
            _carService = carService;
        }

        public IViewComponentResult Invoke()
        {
            // Veritabanından araçları al
            List<Car> cars = _carService.TGetAll(); // Servisten ya da veritabanından alınabilir.

            return View(cars); // Bu veriyi view'a gönderiyoruz
        }
    }
}
