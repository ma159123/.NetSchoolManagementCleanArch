using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Abstractions.infra_abstract;
using SchoolManagement.Core.Abstractions.service_abstract;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Service.Impl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo departmentRepo;
        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        public async Task<bool> CheckDepartmentByIdAsync(int id)
        {
            return await departmentRepo.GetTableNoTracking().AnyAsync(d => d.DID == id);
        }

        public Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return departmentRepo.GetDepartmentByIdAsync(id);
        }
    }
}

