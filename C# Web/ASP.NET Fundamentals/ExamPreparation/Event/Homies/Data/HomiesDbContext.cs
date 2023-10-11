using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Homies.Data.Models.Type;
namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>()
           .HasKey(ep => new { ep.HelperId, ep.EventId });

            modelBuilder.Entity<EventParticipant>()
             .HasOne(ep => ep.Event)
             .WithMany(e => e.EventsParticipants)             
             .OnDelete(DeleteBehavior.NoAction);

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

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Type> Types { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventParticipant> EventsParticipants { get; set; } 
    }
}