using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private Dictionary<string, IWeapon> weapons;
        public IReadOnlyCollection<IWeapon> Models => this.weapons.Values;

        public WeaponRepository()
        {
            weapons = new Dictionary<string, IWeapon>();
        }

        public void Add(IWeapon model)
        {
            weapons.Add(model.Name, model);
        }

        public IWeapon FindByName(string name)
        {
           
            if (weapons.ContainsKey(name))
            {
                return weapons[name];
            }
            else
            {
                return null;
            }
        }

        public bool Remove(IWeapon model)
        {
            bool removed = weapons.Remove(model.Name);
            return removed;
        }
                      
    }                 
}                     
                      