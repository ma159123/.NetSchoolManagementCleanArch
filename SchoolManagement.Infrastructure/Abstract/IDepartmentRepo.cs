using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Bases;

namespace SchoolManagement.Infrastructure.Abstract
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        public Task<Department?> GetDepartmentByIdAsync(int id);
    }
}
