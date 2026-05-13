using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            SupervisedInstructors = new HashSet<Instructor>();
            Subjects = new HashSet<InstructorSubject>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        [ForeignKey(nameof(SuperInstructor))]
        public int? SuperInstructorId { get; set; }
        public Instructor? SuperInstructor { get; set; }
        [InverseProperty(nameof(SuperInstructor))]
        public virtual ICollection<Instructor> SupervisedInstructors { get; set; }
        [ForeignKey(nameof(Department))]
        public int DeptId { get; set; }
        [InverseProperty("Instructors")]
        public Department? Department { get; set; }
        [InverseProperty("Manager")]
        public Department? ManagedDepatment { get; set; }
        [InverseProperty("Instructor")]
        public virtual ICollection<InstructorSubject> Subjects { get; set; }
    }

}