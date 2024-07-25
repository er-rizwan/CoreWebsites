using Microsoft.EntityFrameworkCore;

namespace CoreWeb.Models
{
	public class StudentDBContext:DbContext
	{
        public StudentDBContext(DbContextOptions dbContext):base(dbContext)
        {
                
        }

        public DbSet<Student> Students { get; set; }
    }
}
