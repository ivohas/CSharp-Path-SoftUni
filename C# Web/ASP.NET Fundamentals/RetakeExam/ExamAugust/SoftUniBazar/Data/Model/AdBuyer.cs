using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Model
{
    public class AdBuyer
    {
        [Required]
        public string BuyerId { get; set; } = null!;
        [ForeignKey(nameof(BuyerId))]
        public IdentityUser Buyer { get; set; }
        [Required]
        public int AdId { get; set; }
        [ForeignKey(nameof(AdId))]
        public Ad Ad { get; set; }
    }
}
