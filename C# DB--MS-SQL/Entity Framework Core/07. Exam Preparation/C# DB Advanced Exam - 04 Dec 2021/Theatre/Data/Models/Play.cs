using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(4)]
        [Required]
        public string Title { get; set; } = null!;

        // Min Span 
        [Required]
        public TimeSpan Duration  { get; set; }

        [Range(0.00, 10.00)]
        [Required]
        public float Rating  { get; set; }

        public Genre Genre  { get; set; }

        [MaxLength(700)]
        [Required]
        public string Description { get; set; } = null!;

        [MaxLength(30)]
        [MinLength(4)]
        [Required]
        public string Screenwriter { get; set; } = null!;


        public ICollection<Cast> Casts { get; set; } = new HashSet<Cast>();

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
