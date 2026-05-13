using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasMany(s => s.StudentsSubjects).WithOne(s => s.Subject).HasForeignKey(ssb => ssb.SubID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.InstructorSubjects).WithOne(i => i.Subject).HasForeignKey(i => i.SubId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.DepartmetsSubjects).WithOne(ds => ds.Subject).HasForeignKey(ds => ds.SubID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
