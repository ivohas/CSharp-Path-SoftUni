using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        // Unique
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Founded { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; } = new HashSet<Gun>();
    }
}
