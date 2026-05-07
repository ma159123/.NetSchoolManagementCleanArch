using SchoolManagement.Data.Data;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Service.Abstract
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public IQueryable<Student> GetQuerybleStudents();
        public IQueryable<Student> GetQuerybleFilterStudents(FilterStudentsEnum? filterStudentsEnum, string? search);
        public Task<Student?> GetStudentByIdAsync(int id);
        public Task<Student?> GetStudentByIdWithNoTrackAsync(int id);
        public Task<string> AddStudent(Student student);
        public Task<string> EditStudent(Student student);
        public Task<bool> isPhoneExist(int studentId, string phone);
        public Task<bool> DeleteStudent(Student student);
    }
}
