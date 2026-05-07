using AutoMapper;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Data.Entities;
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
