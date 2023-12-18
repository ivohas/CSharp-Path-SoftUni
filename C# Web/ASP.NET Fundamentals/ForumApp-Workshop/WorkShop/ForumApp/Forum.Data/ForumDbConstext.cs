using ForumApp.Data.Configuration;
using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace ForumApp.Data
{
    public class ForumDbConstext : DbContext
    {

        public ForumDbConstext(DbContextOptions<ForumDbConstext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modulBuilder)
        {

            modulBuilder.ApplyConfiguration(new PostEntityConfiguration());

            base.OnModelCreating(modulBuilder);
        }
    }
}
