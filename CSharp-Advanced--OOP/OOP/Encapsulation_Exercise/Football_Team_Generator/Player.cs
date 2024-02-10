using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Team_Generator
{
    public class Player
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhiteSpaceName);
                }
                this.name = value;
            }
        }

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        public Stats Stats { get; private set; }
    }
}
