using AutoMapper;

namespace SchoolManagement.Core.Features.Mapping.StudentMap
{
    public partial class StudentProfiler : Profile
    {
        public StudentProfiler()
        {
            GetStudentsListMapping();
            GetStudentMapping();
            AddStudentMapping();
            EditStudentMapping();
            GetPaginatedStudentsListMapping();
        }
    }
}
