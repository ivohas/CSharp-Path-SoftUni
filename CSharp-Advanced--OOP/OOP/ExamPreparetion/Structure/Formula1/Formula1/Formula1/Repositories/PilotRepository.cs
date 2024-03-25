using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;
        public PilotRepository()
        {
            models= new HashSet<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)this.models;

        public void Add(IPilot model)
        {
           models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot pilot = models.FirstOrDefault(x => x.FullName == name);
            return pilot;
        }

        public bool Remove(IPilot model)
        {
           bool removed = models.Remove(model);
            return removed;
        }
    }
}
