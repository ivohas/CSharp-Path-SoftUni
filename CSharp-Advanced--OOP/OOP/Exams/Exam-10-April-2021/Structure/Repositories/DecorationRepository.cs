using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> models;
        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)this.models;

        public void Add(IDecoration model) => this.models.Add(model);

        public IDecoration FindByType(string type) => this.models.FirstOrDefault(m => m.GetType().Name == type);

        public bool Remove(IDecoration model) => this.models.Remove(model);
    }
}
