using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
   
    public class ServiceController(IServiceSevice service , IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = service.TGetAll();
            var services = mapper.Map<List<ResultServiceDto>>(values);
            return View(services);
        }
    }
}
