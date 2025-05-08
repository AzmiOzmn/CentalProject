using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ProcessDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultProcessComponent : ViewComponent
    {
        private readonly IMapper mapper;
        private readonly IProcessService processService;

        public _DefaultProcessComponent(IMapper mapper, IProcessService processService)
        {
            this.mapper = mapper;
            this.processService = processService;
        }

        public IViewComponentResult Invoke()
        {
            var values = processService.TGetAll();
            var process = mapper.Map<List<ResultProcessDto>>(values);
            return View(process);
        }
    }
}
