using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportManufacturerDto
    {

 

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        
        // Unique
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        [XmlElement("Founded")]
        public string Founded { get; set; } = null!;
    }
}
