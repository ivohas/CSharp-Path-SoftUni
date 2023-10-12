using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
