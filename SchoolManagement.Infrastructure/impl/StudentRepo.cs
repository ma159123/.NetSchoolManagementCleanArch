using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Bases;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.impl
{
    internal class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        readonly DbSet<Student> students;
        public StudentRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.students = applicationDbContext.Set<Student>();
        }

        //public async Task<string> AddStudent(Student student)
        //{
        //   await AddAsync(student);
        //    return "Add Successfully";
        //}

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = GetTableAsTracking().Include(s => s.Department).FirstOrDefault(s => s.StudID == id);
            return student;
        }

        public async Task<Student?> GetStudentByIdWithNoTrackAsync(int id)
        {
            var student = GetTableNoTracking().Include(s => s.Department).FirstOrDefault(s => s.StudID == id);
            return student;
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            return students.Include(s => s.Department).ToListAsync();
        }

        public async Task<List<Student>> GetStudentsPaginatedAsync(int page, int itemCount)
        {
            int skip = (page - 1) * itemCount;
            return students.Skip(skip).Take(itemCount).ToList();
        }
    }
}
