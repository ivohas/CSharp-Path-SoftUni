using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.ValidationConstants.CategoryConsts;
namespace SoftUniBazar.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
