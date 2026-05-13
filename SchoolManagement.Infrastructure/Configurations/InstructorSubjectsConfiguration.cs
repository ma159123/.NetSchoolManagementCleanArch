using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class InstructorSubjectsConfiguration : IEntityTypeConfiguration<InstructorSubject>
    {
        public void Configure(EntityTypeBuilder<InstructorSubject> builder)
        {
            builder.HasOne(ss => ss.Instructor)
           .WithMany(s => s.Subjects)
           .HasForeignKey(ss => ss.InsId)
           .OnDelete(DeleteBehavior.Restrict).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ss => ss.Subject)
                  .WithMany(sub => sub.InstructorSubjects)
                  .HasForeignKey(ss => ss.SubId)
                  .OnDelete(DeleteBehavior.Restrict).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
