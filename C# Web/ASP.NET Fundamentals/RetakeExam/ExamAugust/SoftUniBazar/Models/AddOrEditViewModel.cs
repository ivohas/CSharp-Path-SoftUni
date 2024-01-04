using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.ValidationConstants.AdConsts;
namespace SoftUniBazar.Models
{
    public class AddOrEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght)]
        public string Name { get; set; } = null!;
        [StringLength(DescriptionMaxLenght, MinimumLength = DescriptionMinLenght)]
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }      
        [Required]
        public string ImageUrl { get; set; } = null!;
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
