using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.AppUser.Commands.Models;

namespace SchoolManagement.Core.Mapping.AppUserMappping
{
    partial class UserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, User>()
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                   .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
