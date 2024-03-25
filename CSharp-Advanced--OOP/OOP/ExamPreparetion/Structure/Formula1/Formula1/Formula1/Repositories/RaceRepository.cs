using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> races;
        public RaceRepository()
        {
            races = new HashSet<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)this.races;

        public void Add(IRace model)
        {
          races.Add(model);
        }

        public IRace FindByName(string name)
        {
            IRace race = races.FirstOrDefault(x => x.RaceName == name);
            return race;
        }

        public bool Remove(IRace model)
        {
            bool result= races.Remove(model);
            return result;
        }
    }
}
