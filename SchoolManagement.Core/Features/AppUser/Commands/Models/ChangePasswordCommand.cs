using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.AppUser.Commands.Models
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
