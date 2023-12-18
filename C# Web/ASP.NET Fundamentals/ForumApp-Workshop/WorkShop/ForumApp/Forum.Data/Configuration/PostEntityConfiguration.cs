using ForumApp.Data.Models;
using ForumApp.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configuration
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeader postSeader;
        public PostEntityConfiguration()
        {
            this.postSeader = new PostSeader();       
        }
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this.postSeader.GeneratePosts());
             
            
        }
        
    }
}
