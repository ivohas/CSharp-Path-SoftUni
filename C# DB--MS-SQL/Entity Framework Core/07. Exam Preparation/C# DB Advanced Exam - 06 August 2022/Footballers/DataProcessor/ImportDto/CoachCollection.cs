using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlRoot("Coaches")]
    public class CoachCollection
    {
        [XmlArray("Coaches")]
        [XmlArrayItem("Coach")]
        public CoachDto[] Coaches { get; set; }
    }
}
