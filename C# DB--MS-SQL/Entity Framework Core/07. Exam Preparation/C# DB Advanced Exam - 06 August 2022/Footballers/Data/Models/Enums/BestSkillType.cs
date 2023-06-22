using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.Data.Models.Enums
{
    [XmlType(IncludeInSchema =true)]
    public enum BestSkillType
    {
        Defence=0,
        Dribble=1,
        Pass=2, 
        Shoot=3,
        Speed=4

    }
}
