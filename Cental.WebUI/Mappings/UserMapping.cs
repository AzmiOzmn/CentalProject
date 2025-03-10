using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, UserRegisterDto>().ReverseMap();
            CreateMap<AppUser, UserResultDto>().ReverseMap();

        }
    }
}
