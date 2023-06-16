using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {

        [XmlElement("Title")]
        [MaxLength(50)]
        [MinLength(4)]
        [Required]
        public string Title { get; set; } = null!;

        // Min Span 
        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Range(0.00, 10.00)]
        [Required]
        [XmlElement("Raiting")]
        // May couze error
        public float Rating { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [MaxLength(700)]
        [Required]
        [XmlElement("Description")]
        public string Description { get; set; } = null!;

        [MaxLength(30)]
        [MinLength(4)]
        [Required]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; } = null!;

    }
}
