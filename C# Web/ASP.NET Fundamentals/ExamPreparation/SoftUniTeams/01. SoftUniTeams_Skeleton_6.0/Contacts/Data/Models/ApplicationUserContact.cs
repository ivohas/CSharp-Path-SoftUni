using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Data.Entites
{
    public class ApplicationUserContact
    {
        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(ContactId))]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
//•	ApplicationUserId – a string, Primary Key, foreign key (required)
//•	ApplicationUser – ApplicationUser
//•	ContactId – an integer, Primary Key, foreign key (required)
//•	Contact – Contact
