using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace assignment_12_EF.Models
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=assignment12EF;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(c => c.StudentId);
            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId);
            modelBuilder.Entity<Resource>()
                .HasKey(c => c.ResourceId);
            modelBuilder.Entity<Homework>()
                .HasKey(c => c.HomeworkId);

            modelBuilder.Entity<Student>()
                .Property(x => x.Name)
                .HasColumnType("varchar(100)");
            modelBuilder.Entity<Student>()
               .Property(x => x.PhoneNumber)
               .HasMaxLength(10);
            modelBuilder.Entity<Course>()
               .Property(x => x.Name)
               .HasColumnType("varchar(80)");
            modelBuilder.Entity<Resource>()
               .Property(x => x.Name)
               .HasColumnType("varchar(50)");

            modelBuilder.Entity<Student>()
                .Property(b => b.Name)
                .IsUnicode(true);
            modelBuilder.Entity<Student>()
                .Property(b => b.PhoneNumber)
                .IsUnicode(false);
            modelBuilder.Entity<Course>()
                .Property(b => b.Name)
                .IsUnicode(true);
            modelBuilder.Entity<Course>()
                .Property(b => b.Description)
                .IsUnicode(true);
            modelBuilder.Entity<Resource>()
                .Property(b => b.Name)
                .IsUnicode(true);
            modelBuilder.Entity<Resource>()
                .Property(b => b.Url)
                .IsUnicode(false);
            modelBuilder.Entity<Homework>()
                .Property(b => b.Content)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .UsingEntity
                (
                    "StudentCourses",
                    q => q.HasOne(typeof(Student)).WithMany().HasForeignKey("StudentsId").HasPrincipalKey(nameof(Student.StudentId)),
                    w => w.HasOne(typeof(Course)).WithMany().HasForeignKey("CourseId").HasPrincipalKey(nameof(Course.CourseId)),
                    e => e.HasKey("StudentId", "CourseId")
                );
        }
    }
}
