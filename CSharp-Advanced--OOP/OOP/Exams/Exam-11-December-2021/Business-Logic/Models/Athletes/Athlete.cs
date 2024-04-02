using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;
using System;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private const int MAX_STAMINA = 100;
        private const int MIN_MEDALS = 0;

        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;
        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }
                fullName = value;
            }
        }

        public string Motivation
        {
            get { return motivation; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }
                motivation = value;
            }
        }

        public int Stamina
        {
            get { return stamina; }
            protected set
            {
                if (value > MAX_STAMINA)
                {
                    this.stamina = MAX_STAMINA;
                    throw new ArgumentException(ExceptionMessages.InvalidStamina);
                }
                stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get { return numberOfMedals; }
            private set
            {
                if (value < MIN_MEDALS)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }
                numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
