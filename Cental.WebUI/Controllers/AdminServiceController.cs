using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    
    public class AdminServiceController(IServiceSevice serviceSevice , IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = serviceSevice.TGetAll();
            var services = mapper.Map<List<ResultServiceDto>>(values);
            return View(services);
        }
    }
}
