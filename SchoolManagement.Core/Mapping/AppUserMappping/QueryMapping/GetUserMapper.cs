using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.AppUser.Queries.Results;

namespace SchoolManagement.Core.Mapping.AppUserMappping
{
    partial class UserProfile
    {
        public void GetUserMapper()
        {
            CreateMap<User, GetUserResponse>()
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
