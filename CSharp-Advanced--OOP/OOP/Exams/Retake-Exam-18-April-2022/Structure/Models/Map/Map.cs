using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public Map()
        {

        }
        public string Fight(ICollection<IHero> players)
        {
            ICollection<IHero> knightList = new List<IHero>(players.Where(p => p.GetType() == typeof(Knight))).ToList();
            ICollection<IHero> barbarianList = new List<IHero>(players.Where(p => p.GetType() == typeof(Barbarian))).ToList();

            int knightsCount = knightList.Count();
            int barbariansCount =  barbarianList.Count();

            int knightDeaths = 0;
            int BarbarianDeaths = 0;
            while (true)
            {
                foreach (Knight knight in knightList)
                {
                    if (knight.IsAlive)
                    {
                        foreach (Barbarian barbarian in barbarianList)
                        {
                            if (barbarian.IsAlive)
                            {
                                if (knight.Weapon.Durability > 0)
                                {
                                    barbarian.TakeDamage(knight.Weapon.DoDamage());
                                    if (!barbarian.IsAlive)
                                    {
                                        BarbarianDeaths++;
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (Barbarian barbarian in barbarianList)
                {
                    if (barbarian.IsAlive)
                    {
                        foreach (Knight knight in knightList)
                        {
                            if (knight.IsAlive)
                            {
                                if (knight.Weapon.Durability > 0)
                                {
                                    knight.TakeDamage(barbarian.Weapon.DoDamage());
                                    if (!knight.IsAlive)
                                    {
                                        knightDeaths++;
                                    }
                                }
                            }
                        }
                    }
                }

                if (BarbarianDeaths == barbariansCount)
                {
                    return $"The knights took {knightDeaths} casualties but won the battle.";
                }
                else if (knightDeaths == knightsCount)
                {
                    return $"The barbarians took {BarbarianDeaths} casualties but won the battle.";
                }
            }
            
        }
    }
}
