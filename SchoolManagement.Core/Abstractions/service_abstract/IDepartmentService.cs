using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Abstractions.service_abstract
{
    public interface IDepartmentService
    {
        public Task<Department?> GetDepartmentByIdAsync(int id);
        public Task<bool> CheckDepartmentByIdAsync(int id);
    }
}
