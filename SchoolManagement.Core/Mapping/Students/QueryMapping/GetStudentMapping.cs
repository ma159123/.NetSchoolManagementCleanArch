using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Data.Entities;


namespace SchoolManagement.Core.Features.Mapping.StudentMap
{
    public partial class StudentProfiler
    {
        public void GetStudentMapping()
        {
            CreateMap<Student, GetStudentResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
