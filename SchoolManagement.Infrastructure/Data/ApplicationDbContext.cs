using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using System.Reflection;

namespace SchoolManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<DepartmetSubject> departmetSubjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorSubject> InstructorSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Department>()
            //    .HasOne(d => d.Manager)
            //    .WithOne(i => i.ManagedDepatment)
            //    .HasForeignKey<Department>(d => d.ManagerId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Instructor>()
            //    .HasOne(i => i.Department)
            //    .WithMany(d => d.Instructors)
            //    .HasForeignKey(i => i.DeptId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Instructor>()
            //    .HasOne(i => i.SuperInstructor)
            //    .WithMany(i => i.SupervisedInstructors)
            //    .HasForeignKey(i => i.SuperInstructorId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
