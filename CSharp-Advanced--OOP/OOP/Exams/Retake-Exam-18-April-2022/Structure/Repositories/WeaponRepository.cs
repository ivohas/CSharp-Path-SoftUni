using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void Add(IWeapon model) => this.weapons.Add(model);

        public IWeapon FindByName(string name) => this.weapons.FirstOrDefault(h => h.Name == name);

        public bool Remove(IWeapon model)
        {
            if (this.weapons.Any(h => h.Name == model.Name))
            {
                this.weapons.Remove(model);
                return true;
            }

            return false;
        }
    }
}
