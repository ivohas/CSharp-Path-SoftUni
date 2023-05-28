
using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Player
{
    public Player()
    {
        this.PlayerStatistics = new HashSet<PlayerStatistic>();
    }

    [Key]
    public int PlayerId { get; set; }
    [Required]
    [MaxLength(ValidationConstans.PlayerNameMaxLenght)]
    public string Name { get; set; } = null!;
    public bool IsInjured { get; set; }
    public int SquadNumber { get; set; }


    [ForeignKey(nameof(Team))]
    public int? TeamId { get; set; }
    public virtual Team? Team { get; set; }

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }
    public virtual Position Position  { get; set; } = null!;

    public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
}
