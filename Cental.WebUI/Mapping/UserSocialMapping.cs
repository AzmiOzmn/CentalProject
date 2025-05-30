﻿using AutoMapper;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class UserSocialMapping : Profile
    {
        public UserSocialMapping()
        {
            CreateMap<UserSocial,ResultUserSocialDto>().ReverseMap();
            CreateMap<UserSocial,UpdateUserSocialDto>().ReverseMap();
            CreateMap<UserSocial,CreateUserSocialDto>().ReverseMap();
        }
    }
}
