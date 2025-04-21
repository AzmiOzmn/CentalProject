using Cental.DtoLayer.UserDtos;

namespace Cental.DtoLayer.UserSocialDtos
{
    public class ResultUserSocialDto
    {

        public int UserSocialId { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public ResultUserDto User { get; set; }

    }
}
