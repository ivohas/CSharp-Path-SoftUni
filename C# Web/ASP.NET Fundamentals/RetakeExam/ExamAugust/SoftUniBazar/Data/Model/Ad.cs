using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.Common.ValidationConstants.AdConsts;
namespace SoftUniBazar.Data.Model
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLenght)]
        public string Name { get; set; } = null!;
        [StringLength(DescriptionMaxLenght)]
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string OwnerId { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; }
        [Required]
        public string ImageUrl { get; set; } = null!;
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
