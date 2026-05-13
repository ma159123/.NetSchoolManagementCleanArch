using AutoMapper;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Core.Features.Mapping.StudentMap
{
    public partial class StudentProfiler 
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>().ForMember(s => s.DID, (op) => op.MapFrom(s=>s.DepartmentId));
        }
    }
}
