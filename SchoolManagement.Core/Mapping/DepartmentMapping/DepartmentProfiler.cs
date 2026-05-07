using AutoMapper;

namespace SchoolManagement.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfiler : Profile
    {
        public DepartmentProfiler()
        {
            MapGetDeptByIdResponse();
        }
    }
}
