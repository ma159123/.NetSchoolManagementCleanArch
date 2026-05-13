using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.AppUser.Commands.Models
{
    public class UpdateUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public String? Address { get; set; }
        public string? Email { get; set; }
    }
}
