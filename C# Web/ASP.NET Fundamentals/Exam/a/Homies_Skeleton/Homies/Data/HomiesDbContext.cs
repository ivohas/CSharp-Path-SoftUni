using Homies.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    using Type = Data.Models.Type;
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            modelBuilder.Entity<EventParticipant>()
                .HasKey(x => new { x.EventId, x.HelperId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Type> Types { get; set; }

        public DbSet<EventParticipant> EventParticipants { get; set; }
    }
}