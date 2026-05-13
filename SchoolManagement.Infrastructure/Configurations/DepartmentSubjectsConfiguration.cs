using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class DepartmentSubjectsConfiguration : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
        {
            builder.HasOne(ds => ds.Department)
        .WithMany(d => d.DepartmentSubjects)
        .HasForeignKey(ds => ds.DID)
        .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ds => ds.Subject)
                  .WithMany(sub => sub.DepartmetsSubjects)
                  .HasForeignKey(ss => ss.SubID)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
