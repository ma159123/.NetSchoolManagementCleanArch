using SchoolManagement.Core.Features.Students.Queries.Results;
using SchoolManagement.Data.Entities;


namespace SchoolManagement.Core.Features.Mapping.StudentMap
{
   public partial class StudentProfiler
    {
       public void GetStudentsListMapping()
        {
            CreateMap<Student, GetStudentsListResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
      
    }
}
