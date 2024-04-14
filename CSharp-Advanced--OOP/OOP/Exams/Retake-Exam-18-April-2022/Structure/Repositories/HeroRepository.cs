using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.heroes.AsReadOnly();

        public void Add(IHero model) => this.heroes.Add(model);

        public IHero FindByName(string name) => this.heroes.FirstOrDefault(h => h.Name == name);

        public bool Remove(IHero model)
        {
            if (this.heroes.Any(h => h.Name == model.Name))
            {
                this.heroes.Remove(model);
                return true;
            }

            return false;
        }
    }
}
