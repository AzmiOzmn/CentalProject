using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminTestimonialController(ITestimonialService testimonialService , IMapper mapper ) : Controller
    {
        public IActionResult Index()
        {
            var values = testimonialService.TGetAll();
            var dto = mapper.Map<List<ResultTestimonialDto>>(values);
            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            testimonialService.TDelete(id);
            return RedirectToAction("Index");

        }
    }
}
