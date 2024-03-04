using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = players.OfType<Knight>().Where(x => x.IsAlive).ToList();
            var barberians= players.OfType<Barbarian>().Where(x => x.IsAlive).ToList();
            while (true)
            {
                bool allKnightsAreDead = true;
                bool allBarberiansAreDead = true;
                //Stage 1
                foreach (var knight in knights.Where(x=>x.IsAlive))
                {
                    allKnightsAreDead = false;
                    foreach (var barb in barberians.Where(x=>x.IsAlive))
                    {
                        barb.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                //Stage 2
                foreach (var barb in barberians.Where(x => x.IsAlive))
                {
                    allBarberiansAreDead = false;
                    foreach (var knight in knights.Where(x => x.IsAlive))
                    {
                        knight.TakeDamage(barb.Weapon.DoDamage());
                    }
                }

                if (!allBarberiansAreDead)
                {
                    int numOfAliveKnights = knights.Count(x => x.IsAlive);
                    int numOfDeads = knights.Count - numOfAliveKnights;
                    return $"The knights took {numOfDeads} casualties but won the battle.";
                }
                if (!allKnightsAreDead )
                {
                    int numOfAliveBarbs=barberians.Count(x => x.IsAlive);
                    int numOfDeads = barberians.Count - numOfAliveBarbs;
                    return $"The barbarians took {numOfDeads} casualties but won the battle.";
                }
            }
        }
    }
}
