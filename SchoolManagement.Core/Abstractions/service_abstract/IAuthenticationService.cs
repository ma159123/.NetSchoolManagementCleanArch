using Microsoft.Extensions.Configuration;
using SchoolManagement.Core.Entities.identity;

namespace SchoolManagement.Core.Abstractions.service_abstract
{
    public interface IAuthenticationService
    {
        public string GenerateUserToken(User user, IConfiguration configuration);
    }
}
