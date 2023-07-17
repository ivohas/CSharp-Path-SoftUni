using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountriesDto
    { 
         
    [MaxLength(60)]
    [MinLength(4)]
    [Required]
    [XmlElement("CountryName")]
    public string CountryName { get; set; } = null!;

    [Required]
  
    [Range(50_000, 10_000_000)]
    [XmlElement("ArmySize")]
    public int ArmySize { get; set; }
    
    }
}
