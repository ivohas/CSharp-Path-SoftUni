using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamDto
    {

        public string? Name { get; set; } = null!;
        public string? Nationality { get; set; } = null!;
        public string? Trophies { get; set; }
        public int[]? Footballers { get; set; }
    }
}
