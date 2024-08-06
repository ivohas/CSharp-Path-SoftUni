using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace BookFindingAndRatingSystem.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
        
        public string? ImageUrl { get; set; }
    }
}
