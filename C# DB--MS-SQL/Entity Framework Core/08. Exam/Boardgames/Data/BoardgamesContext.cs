namespace Boardgames.Data
{
    using Boardgames.Data.Models;
    using Microsoft.EntityFrameworkCore;
    
    public class BoardgamesContext : DbContext
    {
        public BoardgamesContext()
        { 
        }

        public BoardgamesContext(DbContextOptions options)
            : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BoardgameSeller>()
                .HasKey(b => new { b.SellerId, b.BoardgameId });
        }

        public DbSet<BoardgameSeller> BoardgamesSellers { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Boardgame> Boardgames { get; set; }
    }
}
