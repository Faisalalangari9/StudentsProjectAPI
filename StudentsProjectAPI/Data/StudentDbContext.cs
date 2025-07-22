using Microsoft.EntityFrameworkCore;

namespace StudentsProjectAPI.Models
{
    public class StudentDbContext : DbContext  //Class where it gives access to database 
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Seeds department data (adds initial values to DB). so by defult when running the program it will create data in database
        {
            // Seeding Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 101, Name = "COS" },
                new Department { Id = 210, Name = "ISY" },
                new Department { Id = 381, Name = "ISY" },
                new Department { Id = 413, Name = "COS" }
            );
        }

        public DbSet<Department> Departments { get; set; } //Represents Departments table in SQL.
        public DbSet<Student> Students { get; set; }   //Represents Students table in SQL.
    }
}