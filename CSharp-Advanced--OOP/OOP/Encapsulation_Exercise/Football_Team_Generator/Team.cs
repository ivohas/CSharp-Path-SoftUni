using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Football_Team_Generator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name) : this()
        {
            this.Name = name;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhiteSpaceName);
                }
                this.name = value;
            }
        }

        public int Rating => (int)Math.Round(this.players.Average(p => p.Stats.GetOverallStat()), 0);
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = this.players
                .FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException(
                    String.Format(ErrorMessages.PlyaerNotInTeam, playerName, this.Name));
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            if (this.players.Any())
            {
                return $"{this.Name} - {this.Rating}";
            }
            else return $"{this.Name} - {0}";
        }
    }
}
