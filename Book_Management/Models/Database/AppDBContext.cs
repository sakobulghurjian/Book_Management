using Microsoft.EntityFrameworkCore;

namespace Book_Management.Models.Database
{
    public class AppDBContext : DbContext
    {
        public DbSet<BookDB> Books { get; set; }
        public DbSet<CategoryDB> Categories { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
