using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ProcessDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminProcessController(IProcessService processService, IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = processService.TGetAll();
            var dto = mapper.Map<List<ResultProcessDto>>(values);
            return View(dto);
        }
    }
}
