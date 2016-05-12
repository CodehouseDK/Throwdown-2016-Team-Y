using Microsoft.Data.Entity;
using TeamY.Domain;

namespace TeamY.Infrastructure
{
    public class TeamyDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Lunch> Lunches { get; set; }
    }
}
