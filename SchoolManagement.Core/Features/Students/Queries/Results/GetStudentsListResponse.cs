using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Features.Students.Queries.Results
{
    public class GetStudentsListResponse
    {
        public int StudID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }

        public string Phone { get; set; }
        public string DepartmentName { get; set; }
    }
}
