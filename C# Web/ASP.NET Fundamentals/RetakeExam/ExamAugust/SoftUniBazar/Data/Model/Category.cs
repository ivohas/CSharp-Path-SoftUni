using System.ComponentModel.DataAnnotations;
using static SoftUniBazar.Common.ValidationConstants.CategoryConsts;
namespace SoftUniBazar.Data.Model
{
    public class Category
    {
        public Category()
        {
            this.Ads = new List<Ad>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Ad> Ads { get; set; }
    }
}
