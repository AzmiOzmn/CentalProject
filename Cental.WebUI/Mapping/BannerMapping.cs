using AutoMapper;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
          CreateMap<Banner,ResultBannerDto>().ReverseMap();
          CreateMap<Banner,UpdateBannerDto>().ReverseMap();
          CreateMap<Banner,InsertBannerDto>().ReverseMap();
        }
    }
}
