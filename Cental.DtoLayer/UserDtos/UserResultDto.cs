using Cental.DtoLayer.UserSocialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.UserDtos
{
    public class UserResultDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        public string FullName => string.Join(" ", FirstName, LastName); // This is a computed property

        public string UserName { get; set; }

        public string Email { get; set; }

        public IList<string> Roles { get; set; }

        public  List<ResultUserSocialDto> UserSocials { get; set; }
    }
}
