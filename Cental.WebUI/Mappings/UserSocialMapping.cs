using AutoMapper;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class UserSocialMapping : Profile
    {
        public UserSocialMapping()
        {
            //source ==> destination 
            CreateMap<UserSocial, ResultUserSocialDto>().ForMember(dest => dest.SocialMediaUrl, o =>
                                                                                                o.MapFrom(src => src.Url));
            CreateMap<UserSocial, UpdateUserSocialDto>().ReverseMap();
            CreateMap<UserSocial, CreateUserSocialDto>().ReverseMap();
        }
    }
}
