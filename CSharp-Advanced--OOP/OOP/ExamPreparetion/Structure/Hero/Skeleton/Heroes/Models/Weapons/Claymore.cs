using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        const int DAMAGE = 20;
        public Claymore(string name, int durability )
            : base(name, durability, DAMAGE)
        {
        }
    }
}
