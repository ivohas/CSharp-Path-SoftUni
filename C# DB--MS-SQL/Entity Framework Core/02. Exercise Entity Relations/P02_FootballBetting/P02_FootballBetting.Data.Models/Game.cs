
using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Game
{
    public Game()
    {
        this.PlayerStatistics = new HashSet<PlayerStatistic>();
        this.Bets = new HashSet<Bet>();
    }
    // PR. Key 
    [Key]
    public int GameId { get; set; }


    // Teams in the game
    [ForeignKey(nameof(HomeTeam))]
    public int HomeTeamId { get; set; }
    public virtual Team HomeTeam { get; set; } = null!;

    [ForeignKey(nameof(AwayTeam))]
    public int AwayTeamId { get; set; }
    public virtual Team AwayTeam { get; set; } = null!;


    // Gols in the game 
    public byte HomeTeamGoals { get; set; }
    public byte AwayTeamGoals { get; set; }

    // Time for teh game
    public DateTime DateTime { get; set; }

    // Bets 
    public double HomeTeamBetRate { get; set; }
    public double AwayTeamBetRate { get; set; }
    public double DrawBetRate { get; set; }

    // Result 
    [MaxLength(ValidationConstans.GameResultMaxLenght)]
    public string? Result { get; set; }

    public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
}
