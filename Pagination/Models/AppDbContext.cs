using Microsoft.EntityFrameworkCore;

namespace Pagination.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseIdentityColumns();
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
