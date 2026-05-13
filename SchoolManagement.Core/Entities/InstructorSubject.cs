using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Core.Entities
{
    public class InstructorSubject
    {
        [Key]
        public int Id { get; set; }

        public int InsId { get; set; }
        public int SubId { get; set; }

        [ForeignKey(nameof(InsId))]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey(nameof(SubId))]
        public virtual Subject Subject { get; set; }
    }
}