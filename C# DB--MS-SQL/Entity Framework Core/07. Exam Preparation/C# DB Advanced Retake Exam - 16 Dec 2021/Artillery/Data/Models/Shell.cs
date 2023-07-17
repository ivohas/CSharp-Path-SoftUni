using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.Data.Models
{
    public class Shell
    {
        [Key]
        public int Id { get; set; }

        [Range(2, 1_680)]
        [Required]
        public double ShellWeight { get; set; }

        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Caliber { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; } = new HashSet<Gun>();
    }
}
