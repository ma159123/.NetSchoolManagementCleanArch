using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Bases;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.impl
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartmentRepo
    {
        DbSet<Department> _dbSet;
        public DepartmentRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbSet = applicationDbContext.Departments;
        }
        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            var response = await GetTableNoTracking().Include(d => d.Manager)
               .Include(d => d.Instructors)
                .Include(d => d.DepartmentSubjects).ThenInclude(ds => ds.Subject).FirstOrDefaultAsync(d => d.DID == id);
            return response;
        }
    }
}
