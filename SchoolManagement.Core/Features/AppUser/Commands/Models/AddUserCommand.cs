using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.AppUser.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public String? Address { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
