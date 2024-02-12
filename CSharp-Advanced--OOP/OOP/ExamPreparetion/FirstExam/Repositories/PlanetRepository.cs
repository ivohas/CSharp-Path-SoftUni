namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets;

        public void AddItem(IPlanet model) => this.planets.Add(model);

        public IPlanet FindByName(string name) => this.planets.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IPlanet planet = this.planets.FirstOrDefault(x => x.GetType().Name == name);
            if (planet == null)
            {
                return false;
            }

            return this.planets.Remove(planet);
        }
    }
}

