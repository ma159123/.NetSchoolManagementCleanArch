using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.AppUser.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public DeleteUserCommand(string id)
        {
            Id = id;
        }
    }
}
