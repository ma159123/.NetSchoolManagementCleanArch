using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.AppUser.Commands.Models;


namespace SchoolManagement.Core.Mapping.AppUserMappping
{
    partial class UserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, User>().ForMember(u => u.Id, (otp) => otp.Ignore());

        }
    }
}
