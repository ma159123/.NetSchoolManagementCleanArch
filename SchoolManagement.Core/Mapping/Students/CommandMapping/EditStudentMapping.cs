using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Features.Mapping.StudentMap
{
    public partial class StudentProfiler
    {
        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>().ForMember(s => s.DID, (op) => op.MapFrom(s => s.DepartmentId));
        }
    }
}
