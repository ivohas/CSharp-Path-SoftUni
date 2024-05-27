using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly HashSet<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new HashSet<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.models;

        public void AddItem(IPlanet model) => this.models.Add(model);

        public IPlanet FindByName(string name) => models.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name) => models.Remove(models.FirstOrDefault(x => x.Name == name));
    }
}
