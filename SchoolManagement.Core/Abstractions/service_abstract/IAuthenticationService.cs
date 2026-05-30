using Microsoft.Extensions.Configuration;
using SchoolManagement.Core.Entities.identity;
using SchoolManagement.Core.Features.Authentication.Commands.Results;

namespace SchoolManagement.Core.Abstractions.service_abstract
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResult> GenerateUserToken(User user, IConfiguration configuration);
        public Task<JwtAuthResult> RefreshToken(string accessToken, string refreshToken, IConfiguration configuration);
    }
}
