using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artillery.Data.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(60)]
        [MinLength(4)]
        [Required]
        public string CountryName { get; set; } = null!;

        [Required]
        [Range(50_000, 10_000_000)]
        public int ArmySize { get; set; }

       public virtual ICollection<CountryGun> CountriesGuns { get; set; } = new HashSet<CountryGun>(); 
    }
}
