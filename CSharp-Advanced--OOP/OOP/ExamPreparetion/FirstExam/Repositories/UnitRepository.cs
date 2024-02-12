namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;

        public UnitRepository()
        {
            this.units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.units;

        public void AddItem(IMilitaryUnit model) => this.units.Add(model);

        public IMilitaryUnit FindByName(string name) => this.units.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IMilitaryUnit militaryUnit = this.units.FirstOrDefault(x => x.GetType().Name == name);
            if (militaryUnit == null)
            {
                return false;
            }

            return this.units.Remove(militaryUnit);
        }
    }
}

