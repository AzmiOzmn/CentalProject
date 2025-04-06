using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.TGetAll();
            var result = values.Select(about => new ResultAboutDto
            {
                AboutId = about.AboutId,
                Vision = about.Vision,
                Mision = about.Mision,
            }).ToList();
            return View(result);
        }

        [HttpGet]

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(InsertAboutDto model)
        {
            _aboutService.TInsert(new About
            {
                Vision = model.Vision,
                Mision = model.Mision,
                Description1 = model.Description1,
                Description2 = model.Description2,
                StartYear = model.StartYear,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                NameSurname = model.NameSurname,
                JobTitle = model.JobTitle,
                ProfilePicture = model.ProfilePicture
            }); // Manuel Mapping
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var model = _aboutService.TGetById(id);
            var about = new UpdateAboutDto
            {
                AboutId = model.AboutId,
                Vision = model.Vision,
                Mision = model.Mision,
                Description1 = model.Description1,
                Description2 = model.Description2,
                StartYear = model.StartYear,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                NameSurname = model.NameSurname,
                JobTitle = model.JobTitle,
                ProfilePicture = model.ProfilePicture
            };
            return View(about);
        }

        [HttpPost]

        public IActionResult Update(UpdateAboutDto model)
        {
            var about = new About
            {
                AboutId = model.AboutId,
                Vision = model.Vision,
                Mision = model.Mision,
                Description1 = model.Description1,
                Description2 = model.Description2,
                StartYear = model.StartYear,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                NameSurname = model.NameSurname,
                JobTitle = model.JobTitle,
                ProfilePicture = model.ProfilePicture
            };
            _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }

    }
}
