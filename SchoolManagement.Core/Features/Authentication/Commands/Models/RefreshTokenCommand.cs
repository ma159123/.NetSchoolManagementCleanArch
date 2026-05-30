using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Authentication.Commands.Results;

namespace SchoolManagement.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
