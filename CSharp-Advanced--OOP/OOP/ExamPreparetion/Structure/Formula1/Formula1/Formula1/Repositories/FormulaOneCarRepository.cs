using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private ICollection<IFormulaOneCar> models;
        public FormulaOneCarRepository()
        {
            models = new HashSet<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)this.models;

        public void Add(IFormulaOneCar model)
        {
            models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
           IFormulaOneCar car= models.FirstOrDefault(x=>x.Model==name);
            return car;
        }

        public bool Remove(IFormulaOneCar model)
        {
           bool result = models.Remove(model);
            return result;
        }
    }
}
