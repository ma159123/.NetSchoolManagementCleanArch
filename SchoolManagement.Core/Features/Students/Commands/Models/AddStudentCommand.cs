using MediatR;
using SchoolManagement.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolManagement.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand: IRequest<Response<string>>
    {
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }

        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
