using SchoolManagement.Core.Features.Departments.Queries.Results;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfiler
    {
        public void MapGetDeptByIdResponse()
        {

            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.Name))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.Instructors))
                .ForMember(dest => dest.Students, opt => opt.Ignore());

            //CreateMap<Student, DeptStudentResponse>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
            //    .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Name));

            CreateMap<Instructor, DeptInstructorResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Name));

            CreateMap<DepartmetSubject, DeptSubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.SubjectName));
        }


    }
}
