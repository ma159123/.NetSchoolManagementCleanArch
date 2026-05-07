using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Data.Entities;

namespace SchoolManagement.Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(d => d.Manager).WithOne(m => m.ManagedDepatment).HasForeignKey<Department>(d => d.ManagerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(d => d.Students).WithOne(s => s.Department).HasForeignKey(s => s.DID).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(d => d.Instructors).WithOne(i => i.Department).HasForeignKey(i => i.DeptId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(d => d.DepartmentSubjects).WithOne(ds => ds.Department).HasForeignKey(ds => ds.DID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
