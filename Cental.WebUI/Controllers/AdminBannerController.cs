using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBannerController(IBannerService _bannerService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var values =  _bannerService.TGetAll();
            var banners = _mapper.Map<List<ResultBannerDto>>(values);
            return View(banners); 
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Insert(InsertBannerDto model)
        {
            var banner = _mapper.Map<Banner>(model);
            _bannerService.TInsert(banner);
            return RedirectToAction("Index");
        }


    }
}
