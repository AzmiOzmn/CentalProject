using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AboutController(IAboutService aboutService, IMapper mapper) : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = aboutService.TGetAll();
            var abouts = mapper.Map<List<ResultListAboutDto>>(values);
            return View(abouts);
        }
    }
}
