using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTestimonialComponent : ViewComponent
    {
        private readonly ITestimonialService testimonialService;
        private readonly IMapper mapper;

        public _DefaultTestimonialComponent(ITestimonialService testimonialService, IMapper mapper)
        {
            this.testimonialService = testimonialService;
            this.mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = testimonialService.TGetAll();
            var testimonial = mapper.Map<List<ResultTestimonialDto>>(values);
            return View(testimonial);
        }
    }
}
