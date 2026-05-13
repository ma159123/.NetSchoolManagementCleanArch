using AutoMapper;

namespace SchoolManagement.Core.Mapping.AppUserMappping
{
    partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapping();
            GetUserMapper();
            UpdateUserMapping();
        }

    }
}
