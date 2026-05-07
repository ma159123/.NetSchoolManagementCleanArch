using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasOne(ss => ss.Student)
           .WithMany(s => s.Subjects)
           .HasForeignKey(ss => ss.StudID)
           .OnDelete(DeleteBehavior.Restrict).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ss => ss.Subject)
                  .WithMany(sub => sub.StudentsSubjects)
                  .HasForeignKey(ss => ss.SubID)
                  .OnDelete(DeleteBehavior.Restrict).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
