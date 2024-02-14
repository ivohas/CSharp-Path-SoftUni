using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private ICollection<IMilitaryUnit> models;
        public UnitRepository()
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
            IMilitaryUnit unit = models.FirstOrDefault(x => x.GetType().Name == name);
            return unit;
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit=models.FirstOrDefault(x => x.GetType().Name == name);
            bool removed = models.Remove(unit);
            return removed;
        }
    }
}
