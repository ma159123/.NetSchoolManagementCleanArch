using SchoolManagement.Data.Entities;

namespace SchoolManagement.Service.Abstract
{
    public interface IDepartmentService
    {
        public Task<Department?> GetDepartmentByIdAsync(int id);
        public Task<bool> CheckDepartmentByIdAsync(int id);
    }
}
