using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public int Power { get; set; }
        public virtual string CastAbility()
        {
            return $"BaseHero - {this.Name} healed for {this.Power} damage";
        }
    }
}
