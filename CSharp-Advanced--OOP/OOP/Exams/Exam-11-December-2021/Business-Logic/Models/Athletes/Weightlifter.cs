using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int INITIAL_STAMINA = 50;
        private const int WEIGHTLIFTER_STAMINA_PLUS = 10;
        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, INITIAL_STAMINA)
        {
        }

        public override void Exercise() => this.Stamina += WEIGHTLIFTER_STAMINA_PLUS;
    }
}
