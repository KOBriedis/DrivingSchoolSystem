using DrivingSchoolSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Data
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
