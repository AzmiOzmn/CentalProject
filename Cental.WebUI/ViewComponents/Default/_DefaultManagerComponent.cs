﻿using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultManagerComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        

     

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var managers = await _userManager.GetUsersInRoleAsync("Manager");
            var dto = managers.Adapt<IList<UserResultDto>>();
            return View(dto.TakeLast(4).ToList());
        }
    }
}
