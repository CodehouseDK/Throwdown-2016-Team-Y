using Microsoft.Data.Entity;
using TeamY.Domain;

namespace TeamY.Infrastructure
{
    public class TeamyDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Team> Teams { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UserState> UserStates { get; set; }

        public DbSet<Lunch> Lunches { get; set; }

        public DbSet<MoodRegistration> MoodRegistrations { get; set; }
    }
}
