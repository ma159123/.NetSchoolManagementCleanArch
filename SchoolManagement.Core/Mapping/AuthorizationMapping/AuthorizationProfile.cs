using AutoMapper;

namespace SchoolManagement.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            GetRolesQueryResponseMapper();
        }
    }
}
