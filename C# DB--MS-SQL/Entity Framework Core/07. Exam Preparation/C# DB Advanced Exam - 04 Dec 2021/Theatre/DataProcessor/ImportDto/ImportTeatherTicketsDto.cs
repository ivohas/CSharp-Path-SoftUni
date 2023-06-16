using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTeatherTicketsDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(typeof(sbyte), "1", "10")]
        public sbyte NumberOfHalls { get; set; }

        [MaxLength(30)]
        [MinLength(4)]
        [Required]
        public string Director { get; set; } = null!;

        public ImportTicketsDto[] Tickets { get; set; }
    }
}
