using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly HashSet<IWeapon> models;
        public WeaponRepository()
        {
            this.models = new HashSet<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void AddItem(IWeapon model) => this.models.Add(model);

        public IWeapon FindByName(string name) => this.models.FirstOrDefault(w => w.GetType().Name == name);

        public bool RemoveItem(string name) => this.models.Remove(this.models.FirstOrDefault(w => w.GetType().Name == name));
    }
}
