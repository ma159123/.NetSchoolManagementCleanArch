using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.Features.Authorization.Queries.Results;

namespace SchoolManagement.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile
    {
        public void GetRolesQueryResponseMapper()
        {
            CreateMap<IdentityRole, GetRoleItemQueryResponse>();
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
