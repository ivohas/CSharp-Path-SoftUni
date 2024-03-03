using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string racename;
        private int laps;
        private bool tookPlace = false;
        private ICollection<IPilot> pilots;
        private Race()
        {
            pilots = new HashSet<IPilot>();
        }

        public Race(string raceName, int numberOfLaps)
            :this()
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
        }

        public string RaceName
        {
            get => this.racename;
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid race name: {racename}.");
                }
                if (value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {racename}.");
                }
                this.racename = value;

            }


        }

        public int NumberOfLaps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {laps}.");
                }
                this.laps = value;
            }
        }

        public bool TookPlace { get => this.tookPlace;  set => this.tookPlace = value; }

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
          
            var sb = new StringBuilder();
            sb.AppendLine($"The {RaceName} race has:")
               .AppendLine($"Participants: {pilots.Count}")
               .AppendLine($"Number of laps: {laps}")
               .Append($"Took place: {TookPlace}");
           return sb.ToString();
        }
    }
}
