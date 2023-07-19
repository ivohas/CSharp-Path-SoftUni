using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Boardgame")]
    public class BoardGameExportDto
    {
        [MaxLength(20)]
        [MinLength(10)]
        [Required]
        [XmlElement("BoardgameName")]
        public string BoardgameName { get; set; } = null!;
        [Range(2018, 2023)]
        [Required]
        [XmlElement("BoardgameYearPublished")]
        public string BoardgameYearPublished { get; set; }
    }
}
