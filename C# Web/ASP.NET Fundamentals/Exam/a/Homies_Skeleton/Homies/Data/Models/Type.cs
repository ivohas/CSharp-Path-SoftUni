using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    using static Common.EntityValidationConstraints.Type;
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
