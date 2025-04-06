using AutoMapper;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            var thisYear = DateTime.Now.Year;

            CreateMap<About, ResultListAboutDto>().ForMember(dst => dst.ExperienceYear, o => o.MapFrom(src => thisYear - src.StartYear));
        }
    }
}
