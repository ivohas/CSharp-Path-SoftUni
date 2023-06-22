using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        [Required]
        [ForeignKey(nameof(TeamId))]
        public int TeamId  { get; set; }

        public virtual  Team Team { get; set; }

        [ForeignKey(nameof(FootballerId))]
        public int FootballerId  { get; set; }

        public virtual Footballer Footballer { get; set; }
    }
}
