using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
    {
       
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; } = null!;
        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;
        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Description { get; set; } = null!;
        [Required]
        public string Rating { get; set; } = null!;
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
