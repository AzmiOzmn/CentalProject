using AutoMapper;
using Cental.DtoLayer.RoleDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController(RoleManager<AppRole> roleManager) : Controller
    {
        public IActionResult Index()
        {
            var values = roleManager.Roles.ToList();
            var dto = values.Adapt<List<ResultRoleDto>>();
            return View(dto);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Insert(CreateRoleDto model)
        {
            var role = model.Adapt<AppRole>();
            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(model);
                }
            }
            return RedirectToAction("Index");




        }

        public async Task<IActionResult> Delete(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            var result = await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var role = await roleManager.FindByIdAsync(id.ToString());
            var dto = role.Adapt<UpdateRoleDto>();
            return View(dto);
        }

        [HttpPost]

        public async Task<IActionResult> Update(UpdateRoleDto model)
        {
            var role = model.Adapt<AppRole>();
            var result = await roleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(model);
                }
            }
            return RedirectToAction("Index");

        }

    }
}