using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class TruckDto
    {

        [XmlElement("RegistrationNumber")]
        [MaxLength(8)]
        [MinLength(8)]
        [RegularExpression(@"[A-Z]{2}\d{4}[A-Z]{2}")]
        public string? RegistrationNumber { get; set; }

        [MinLength(17)]
        [MaxLength(17)]
        [Required]
        [XmlElement("VinNumber")]
        public string VinNumber { get; set; } = null!;

        [Range(950, 1420)]
        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }

        [Range(5000, 29000)]
        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [Range(0, 3)]
        public int CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Required]
        [Range(0,4)]
        public int MakeType { get; set; }      
    }
}
