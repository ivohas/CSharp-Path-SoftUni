using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly Dictionary<string,IHero> heroes;
        public IReadOnlyCollection<IHero> Models => this.heroes.Values;

        public HeroRepository()
        {
            this.heroes = new Dictionary<string,IHero>();
        }

        public void Add(IHero model)
        {
            heroes.Add(model.Name, model);
        }

        public IHero FindByName(string name)
        {
          
            if (heroes.ContainsKey(name)) 
            { 
                return heroes[name];
            }
            else
            {
                return null;
            }
        }

        public bool Remove(IHero model)
        {
             bool isItremoved= heroes.Remove(model.Name);
            return isItremoved;
        }
    }
}
