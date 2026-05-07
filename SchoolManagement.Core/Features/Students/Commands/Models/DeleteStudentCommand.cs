using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            this.Id = id;
        }
    }
}
