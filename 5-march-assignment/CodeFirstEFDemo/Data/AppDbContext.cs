using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo.Data
{
    class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=CodeFirstEFDemoDB;" +
                "User Id=sa;Password=Anand@123;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "John Doe" },
                new Author { Id = 2, Name = "Jane Smith" }
            );

            // Seed Courses (with AuthorId)
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "C# Basics", Description = "Intro to C#", level = CourseLevel.Beginner, AuthorId = 1 },
                new Course { Id = 2, Title = "Advanced .NET", Description = "Deep dive into .NET", level = CourseLevel.Intermediate, AuthorId = 1 },
                new Course { Id = 3, Title = "Azure Fundamentals", Description = "Cloud basics", level = CourseLevel.Beginner, AuthorId = 2 }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice Johnson" },
                new Student { Id = 2, Name = "Bob Wilson" },
                new Student { Id = 3, Name = "Carol Davis" }
            );

            // Configure Many-to-Many relationship between Course and Student
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses);

            // Seed Many-to-Many join table
            modelBuilder
                .Entity("CourseStudent")
                .HasData(
                    new { CoursesId = 1, StudentsId = 1 },  // Alice in C# Basics
                    new { CoursesId = 1, StudentsId = 2 },  // Bob in C# Basics
                    new { CoursesId = 2, StudentsId = 1 },  // Alice in Advanced .NET
                    new { CoursesId = 2, StudentsId = 3 },  // Carol in Advanced .NET
                    new { CoursesId = 3, StudentsId = 2 }   // Bob in Azure
                );
        }

    }
}
