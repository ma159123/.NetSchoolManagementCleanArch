using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Abstractions.infra_abstract
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        public Task<Department?> GetDepartmentByIdAsync(int id);
    }
}
