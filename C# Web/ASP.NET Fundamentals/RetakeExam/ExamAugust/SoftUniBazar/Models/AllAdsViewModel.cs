using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.ValidationConstants.AdConsts;
namespace SoftUniBazar.Models
{
    public class AllAdsViewModel
    {
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
        public string Owner { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        [Required]
        public DateTime CreatedOn { get; set; }

        public string Category { get; set; }
    }
}
