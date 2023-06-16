using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [MinLength(4)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        [MinLength(1)]
        [Required]
        public sbyte NumberOfHalls  { get; set; }

        [MaxLength(30)]
        [MinLength(4)]
        [Required]
        public string Director { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
   }
}
