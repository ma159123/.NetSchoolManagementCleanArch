using SchoolManagement.Core.Wrapper;

namespace SchoolManagement.Core.Features.Departments.Queries.Results
{
    public class GetDepartmentByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }
        public PaginatedList<DeptStudentResponse>? Students { get; set; }
        public List<DeptSubjectResponse>? Subjects { get; set; }
        public List<DeptInstructorResponse>? Instructors { get; set; }
    }

    public class DeptStudentResponse
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
    }
    public class DeptInstructorResponse
    {
        public int Id { get; set; }
        public string InstructorName { get; set; }
    }
    public class DeptSubjectResponse
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
    }
}
