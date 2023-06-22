using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.Data.Models.Enums
{

    [XmlType(IncludeInSchema =true)]
    public enum PositionType
    {
        Goalkeeper=0,
        Defender=1, 
        Midfielder=2, 
        Forward=3

    }
}
