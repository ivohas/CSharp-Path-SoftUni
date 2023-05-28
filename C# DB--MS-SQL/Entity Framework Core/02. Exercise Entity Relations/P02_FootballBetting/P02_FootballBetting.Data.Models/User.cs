using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class User
{
    public User()
    {
        this.Bets = new HashSet<Bet>();
    }
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(ValidationConstans.UsernameMaxLength)]
    public string Username { get; set; } = null!;
    [Required]
    [MaxLength(ValidationConstans.PasswordMaxLength)]
    public string Password { get; set; } = null!;


    [Required]
    [MaxLength(ValidationConstans.EmailMaxLenght)]
    public string Email { get; set; } = null!;


    [Required] 
    [MaxLength(ValidationConstans.UsernameMaxLength)]
    public string Name { get; set; } = null!;

    public decimal Balance { get; set; }

    public virtual ICollection<Bet>  Bets { get; set; }
}
