using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private ICollection<IVessel> models;
        public VesselRepository()
        {
            models = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)this.models;

        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            IVessel vessel = models.FirstOrDefault(x => x.Name == name);
            if (vessel!=null)
            {
                return vessel;
            }

            return null;
        }

        public bool Remove(IVessel model)
        {
           bool check= models.Remove(model);
            if (check)
                return true;
            else
            {
                return false;
            }
        }
    }
}
