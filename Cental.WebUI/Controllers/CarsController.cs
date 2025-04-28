using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.Enums;
using Cental.WebUI.Extansions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    public class CarsController(ICarService carService, IBrandService brandService,CentalContext context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult FilterCars()
        {

            var cars = carService.TGetAll();

            ViewBag.brands = (from x in cars
                              select new SelectListItem
                              {
                                  Text = x.Brand.BrandName + " " + x.ModelName,
                                  Value = x.Brand.BrandName + " " + x.ModelName
                              }
                              ).ToList();




            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gasTypes = GetEnumValues.GetEnums<GearTypes>();




            return PartialView();
        }

        [HttpPost]

        //public IActionResult FilterCars(string car, string gear, int year, string gas)
        //{
        //    if (string.IsNullOrEmpty(car) || string.IsNullOrEmpty(car) || string.IsNullOrEmpty(gear)|| string.IsNullOrEmpty(gas) || year>0)
        //    {
        //        var  values = context.Cars.Where(x=> x.Brand.BrandName + " " + x.ModelName==car && )
                    
        //    }
        //}
    }
}
