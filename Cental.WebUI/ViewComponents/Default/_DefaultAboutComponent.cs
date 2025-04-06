using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultAboutComponent(IAboutService _aboutService , IMapper _mapper) : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var values = _aboutService.TGetAll();
            var abouts = _mapper.Map<List<ResultListAboutDto>>(values);
            return View(abouts);
        }
    }
}
