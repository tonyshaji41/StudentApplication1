using Microsoft.EntityFrameworkCore;
using StudentApplication1.Models;

namespace StudentApplication1.Data
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Mark { get; set; }

    }

    
}
