using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
 
    public class ClientDto
    {

        
        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; } 

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; } = null!;

        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; } = null!;

        [JsonProperty("Trucks")]
        public int[] TrucksId { get; set; }
    }
}
