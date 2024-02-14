using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> models;
        public IReadOnlyCollection<IPlanet> Models =>(IReadOnlyCollection<IPlanet>)this.models;

        public void AddItem(IPlanet model)
        {
           models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = models.FirstOrDefault(x => x.GetType().Name == name);
            return planet;
        }

        public bool RemoveItem(string name)
        {
            IPlanet planet = models.FirstOrDefault(x => x.GetType().Name == name);
            bool removed = models.Remove(planet);
            return removed;
        }
    }
}
