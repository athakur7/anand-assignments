using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFinAsp.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<Author> authors { set; get; }
        public DbSet<Course> courses { set; get; }
        public DbSet<Student> students { set; get; }
    }
}
