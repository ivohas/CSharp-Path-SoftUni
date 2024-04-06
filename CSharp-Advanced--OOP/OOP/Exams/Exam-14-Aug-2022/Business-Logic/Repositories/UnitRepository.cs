using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly HashSet<IMilitaryUnit> models;
        public UnitRepository()
        {
            models = new HashSet<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => this.models;

        public void AddItem(IMilitaryUnit model) => this.models.Add(model);

        public IMilitaryUnit FindByName(string name) => this.models.FirstOrDefault(u => u.GetType().Name == name);
        
        public bool RemoveItem(string name) => this.models.Remove(this.models.FirstOrDefault(u => u.GetType().Name == name));
    }
}
