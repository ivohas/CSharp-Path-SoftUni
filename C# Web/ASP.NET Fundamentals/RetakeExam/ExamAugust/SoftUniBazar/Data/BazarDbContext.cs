using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data.Model;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdBuyer>(entity =>
            {
                entity.HasKey(ab => new { ab.BuyerId, ab.AdId });

                entity.HasOne(ab => ab.Buyer)
                    .WithMany()
                    .HasForeignKey(ab => ab.BuyerId)
                    .OnDelete(DeleteBehavior.NoAction); // Set to NoAction or Restrict based on your requirements

                entity.HasOne(ab => ab.Ad)
                    .WithMany()
                    .HasForeignKey(ab => ab.AdId)
                    .OnDelete(DeleteBehavior.NoAction); // Set to NoAction or Restrict based on your requirements
            });
            modelBuilder.Entity<AdBuyer>()
          .HasKey(ep => new { ep.BuyerId, ep.AdId });
           

            modelBuilder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cars"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Clothes"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Technology"
                });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdBuyer> AdBuyers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}