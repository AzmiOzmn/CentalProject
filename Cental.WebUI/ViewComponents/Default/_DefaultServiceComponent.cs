using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDto;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultServiceComponent : ViewComponent
    {
        private readonly IServiceSevice serviceSevice;
        private readonly IMapper mapper;

        public _DefaultServiceComponent(IMapper mapper, IServiceSevice serviceSevice)
        {
            this.mapper = mapper;
            this.serviceSevice = serviceSevice;
        }

        public IViewComponentResult Invoke()
        {
            var values = serviceSevice.TGetAll();
            var services = mapper.Map<List<ResultServiceDto>>(values);
            return View(services);
        }
    }
}
