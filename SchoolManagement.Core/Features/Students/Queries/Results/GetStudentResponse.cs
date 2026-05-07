using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolManagement.Core.Features.Students.Queries.Results
{
    public class GetStudentResponse
    {
        public int StudID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        public string DepartmentName { get; set; }
    }
}
