using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Name = name;
            this.Power = 100;
        }

        public override string CastAbility()
        {
            return $"Warrior - {this.Name} hit for {this.Power} damage";
        }
    }
}
