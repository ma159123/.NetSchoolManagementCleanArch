using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Service.Abstract;

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

