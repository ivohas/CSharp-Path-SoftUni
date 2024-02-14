using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IMilitaryUnit>
    {
        private ICollection<IMilitaryUnit> models;
        public WeaponRepository()
        {
            models = new HashSet<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)this.models;
        public void AddItem(IMilitaryUnit model)
        {
            models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            IMilitaryUnit weapon = models.FirstOrDefault(x => x.GetType().Name == name);
            return weapon;
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit weapon = models.FirstOrDefault(x => x.GetType().Name == name);
            bool removed = models.Remove(weapon);
            return removed;
        }
    }
}
