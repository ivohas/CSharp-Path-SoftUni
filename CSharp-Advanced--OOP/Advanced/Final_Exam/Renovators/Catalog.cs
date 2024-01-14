using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> renovators = new List<Renovator>();
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;

        public Catalog()
        {

        }
        public Catalog(string name, int NeededRenovators, string project)
        {
            this.Name = name;   
            this.NeededRenovators = NeededRenovators;
            this.Project = project;
        }
       
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
                
            renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (renovators.Contains(renovators.Find(r => r.Name.Equals(name))))
            {
                Renovator renovator = renovators.Find(r => r.Name.Equals(name));
                renovators.Remove(renovator);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            if (renovators.Any(r => r.Type.Equals(type)))
            {
                return renovators.RemoveAll(r => r.Type == type); ;
            }
            return 0;
        }
        public Renovator HireRenovator(string name)
        {
            if (renovators.Contains(renovators.Find(r => r.Name.Equals(name))))
            {
                Renovator renov = renovators.Find(r => r.Name.Equals(name));
                renov.Hired = true;
                return renov;
            }
              return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> hardWorkRenovators = new List<Renovator>(renovators.Where(r => r.Days >= days));
            return hardWorkRenovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var item in renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
