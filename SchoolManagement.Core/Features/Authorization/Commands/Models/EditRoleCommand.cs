using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : IRequest<Response<String>>
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
