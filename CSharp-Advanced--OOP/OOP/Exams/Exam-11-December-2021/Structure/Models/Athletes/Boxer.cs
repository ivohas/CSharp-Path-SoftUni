using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int INITIAL_STAMINA = 60;
        private const int BOXER_STAMINA_PLUS = 15;
        public Boxer(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, INITIAL_STAMINA)
        {
        }

        public override void Exercise() => this.Stamina += BOXER_STAMINA_PLUS;
    }
}
