using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Color
{

    public Color()
    {
        this.SecondaryKitColor = new HashSet<Team>();
        this.PrimaryKitColor = new HashSet<Team>();
    }
    [Key]
    public int ColorId { get; set; }

    [Required]
    [MaxLength(ValidationConstans.ColorTeamMaxLenght)]
    public string Name { get; set; } = null!;

    // todo relacii
    [InverseProperty(nameof(Team.PrimaryKitColor))]
    public virtual ICollection<Team> PrimaryKitColor { get; set; }
    [InverseProperty(nameof(Team.SecondaryKitColor))]
    public  virtual ICollection<Team> SecondaryKitColor { get; set; }
}
