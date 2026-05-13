using SchoolManagement.Core.Abstractions.infra_abstract;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Abstract
{
    public interface IStudentRepo : IGenericRepo<Student>
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<Student?> GetStudentByIdWithNoTrackAsync(int id);
        public Task<List<Student>> GetStudentsPaginatedAsync(int page, int itemCount);


        // Task<string> AddStudent(Student student);
    }
}
