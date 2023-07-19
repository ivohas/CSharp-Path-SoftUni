using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [MinLength(10)]
        [Required]
        public string Name { get; set; } = null!;

        [Range(1.00,10.00)]
        [Required]
        public double Rating  { get; set; }

        [Range(2018,2023)]
        [Required]
        public int YearPublished  { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }
        [Required]
        public string Mechanics { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Creator))]
        public int CreatorId  { get; set; }

        public Creator Creator { get; set; }

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();
    }
}
