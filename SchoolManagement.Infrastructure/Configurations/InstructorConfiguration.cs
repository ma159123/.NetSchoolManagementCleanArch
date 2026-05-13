using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasMany(ins => ins.SupervisedInstructors).WithOne(s => s.SuperInstructor).HasForeignKey(s => s.SuperInstructorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Department).WithMany(d => d.Instructors).HasForeignKey(s => s.DeptId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.ManagedDepatment).WithOne(d => d.Manager).HasForeignKey<Department>(d => d.ManagerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(i => i.Subjects).WithOne(isub => isub.Instructor).HasForeignKey(isub => isub.InsId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
