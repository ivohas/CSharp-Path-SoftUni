using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class SellerDtoImport
    {
        [MaxLength(20)]
        [MinLength(5)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(30)]
        [MinLength(2)]
        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;


        [Required]
        [RegularExpression(@"^www\.[a-zA-Z0-9-]+\.com$")]
        public string Website { get; set; } = null!;


        public int[] Boardgames { get; set; }
    }
}
