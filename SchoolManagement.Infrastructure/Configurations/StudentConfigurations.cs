using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasOne(s => s.Department).WithMany(d => d.Students).HasForeignKey(s => s.DID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.Subjects).WithOne(sb => sb.Student).HasForeignKey(sb => sb.StudID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
