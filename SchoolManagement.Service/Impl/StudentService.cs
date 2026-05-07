using SchoolManagement.Data.Data;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Service.Abstract;

namespace SchoolManagement.Service.Impl
{
    internal class StudentService : IStudentService
    {
        public IStudentRepo studentRepo { get; }
        public StudentService(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }


        public Task<List<Student>> GetStudentsAsync()
        {
            return studentRepo.GetStudentsAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await studentRepo.GetByIdAsync(id: id);
        }

        public async Task<Student?> GetStudentByIdWithNoTrackAsync(int id)
        {
            return await studentRepo.GetStudentByIdWithNoTrackAsync(id: id);
        }

        public async Task<string> AddStudent(Student student)
        {
            //check if exist
            var oldStudent = studentRepo.GetTableNoTracking().FirstOrDefault(s => s.Phone == student.Phone);
            if (oldStudent != null)
            {
                return "Student Exist";
            }
            //add
            await studentRepo.AddAsync(student);
            return "Added Successfully";
        }

        public async Task<string> EditStudent(Student student)
        {
            await studentRepo.UpdateAsync(student);
            return "Edited!";
        }

        public async Task<bool> isPhoneExist(int studentId, string phone)
        {
            var student = studentRepo.GetTableNoTracking().FirstOrDefault(s => s.StudID != studentId && s.Phone == phone);
            if (student != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteStudent(Student student)
        {
            try
            {
                await studentRepo.DeleteAsync(student);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IQueryable<Student> GetQuerybleStudents()
        {
            var students = studentRepo.GetTableNoTracking();
            return students;
        }

        public IQueryable<Student> GetQuerybleFilterStudents(FilterStudentsEnum? filterStudentsEnum, string? search)
        {
            var students = studentRepo.GetTableNoTracking();
            if (filterStudentsEnum.HasValue)
                switch (filterStudentsEnum)
                {
                    case FilterStudentsEnum.Name:
                        {
                            students = students.OrderBy(e => e.Name);
                            break;
                        }
                    case FilterStudentsEnum.Address:
                        {
                            students = students.OrderBy(e => e.Address);
                            break;
                        }
                    case FilterStudentsEnum.Phone:
                        {
                            students = students.OrderBy(e => e.Phone);
                            break;
                        }
                    case FilterStudentsEnum.DepartmentName:
                        {
                            students = students.OrderBy(e => e.Department.DName);
                            break;
                        }
                }

            if (search == null) return students;
            return students.Where(s => s.Name.Contains(search) || s.Address.Contains(search));
        }
    }
}
