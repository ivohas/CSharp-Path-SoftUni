using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Team
{
    public Team()
    {
        this.HomeGames = new HashSet<Game>();
        this.AwayGame = new HashSet<Game>();

        this.Players = new HashSet<Player>();
    }

    [Key] // Primary key 
    public int TeamId { get; set; }

    [Required] // Not null
    [MaxLength(ValidationConstans.TeamNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstans.TeamLogoUrlMaxLengh)]
    public string? LogoUrl { get; set; }

    [Required]
    [MaxLength(ValidationConstans.TeamInitialsLenght)]
     public string Initials { get; set; } = null!;

    public decimal Budget { get; set; }

    [ForeignKey(nameof(PrimaryKitColor))]
    public int PrimaryKitColorId { get; set; }
    public virtual Color PrimaryKitColor { get; set; } = null!;

    [ForeignKey(nameof(SecondaryKitColor))]
    public int SecondaryKitColorId { get; set; } 

    public virtual Color SecondaryKitColor { get; set; }= null!;

    [ForeignKey(nameof(Town))]
      public int TownId { get; set; }
    public virtual Town Town { get; set; } = null!;


    [InverseProperty(nameof(Game.HomeTeam))]
    public virtual ICollection<Game> HomeGames { get; set; }

    [InverseProperty(nameof(Game.AwayTeam))]
    public virtual ICollection<Game> AwayGame { get; set; }

    public virtual ICollection<Player> Players { get; set; }
}
