using MediatR;
using SchoolManagement.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int StudID { get; set; }
        [StringLength(200)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }

        public string? Phone { get; set; }
        public int? DepartmentId { get; set; }
    }
}
