using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class MySocialController : Controller
    {
        private readonly IUserSocialService _userSocialService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public MySocialController(IUserSocialService userSocialService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userSocialService = userSocialService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var socials = _userSocialService.TGetSocialsByUserId(user.Id);

            var result = _mapper.Map<List<ResultUserSocialDto>>(socials); // ✨ burada dönüşüm yapılıyor
            return View(result);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CreateUserSocialDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var newSocial = _mapper.Map<UserSocial>(model);
            newSocial.UserId = user.Id;
            _userSocialService.TInsert(newSocial);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _userSocialService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
