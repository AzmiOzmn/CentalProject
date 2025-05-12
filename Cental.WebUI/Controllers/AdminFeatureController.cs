using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminFeatureController(IFeatureService featureService , IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = featureService.TGetAll();
            var dto = mapper.Map<List<ResultFeatureDto>>(values);
            return View(dto);
        }
    }
}
