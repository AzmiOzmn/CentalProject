using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminBrandController(IBrandService _brandService, IMapper _mapper) : Controller

    {
        
        public IActionResult Index()
        {
            var values = _brandService.TGetAll();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            _brandService.TDelete(id);
             return RedirectToAction("Index");
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Brand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _brandService.TInsert(model);
            return RedirectToAction("Index");
        }
    }
}
