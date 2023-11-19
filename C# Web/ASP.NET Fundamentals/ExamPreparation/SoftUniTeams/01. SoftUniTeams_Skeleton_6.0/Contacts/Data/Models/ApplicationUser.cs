using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Entites
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]   
        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public int Password { get; set; }

        public ICollection<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}
//•	Has an Id – a string, Primary Key
//•	Has a UserName – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed) – no max length required for a hashed password in the database (required)
//•	Has ApplicationUsersContacts – a collection of type ApplicationUserContact

