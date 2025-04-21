using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class UserSocialManager : IGenericManager<UserSocial>, IUserSocialService
    {
        private readonly IMapper mapper;
        private readonly IUserSocialDal _userSocialDal;
        public UserSocialManager(IGenericDal<UserSocial> genericDal, IMapper mapper, IUserSocialDal userSocialDal) : base(genericDal)
        {
            this.mapper = mapper;
            _userSocialDal = userSocialDal;
        }

        public List<ResultUserSocialDto> TGetSocialsByUserId(int userId)
        {
            var values = _userSocialDal.GetSocialsByUserId(userId);
            return mapper.Map<List<ResultUserSocialDto>>(values);
        }
    }
}
