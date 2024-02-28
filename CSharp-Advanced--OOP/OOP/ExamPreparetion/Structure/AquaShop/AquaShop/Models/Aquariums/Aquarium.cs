using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;

        private Aquarium()
        {
            this.Decorations = new HashSet<IDecoration>();
            this.Fish = new HashSet<IFish>();
        }

        protected Aquarium(string name, int capacity):this()
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Capacity {
            get;
            private set;
        }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
            
        }

        public void AddFish(IFish fish)
        {
            if (Capacity > Fish.Count)
            {
                Fish.Add(fish);
            }
            else
                throw new InvalidOperationException("Not enough capacity.");
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            if (Fish.Count > 0)
            {
                StringBuilder sb= new StringBuilder ();
                sb.AppendLine($"Fish: {this.Name}({this.GetType()})")
                    .AppendLine(String.Join(", ", Fish.Select(x => x)));
                sb.AppendLine($"Decorations: {Decorations.Count}")
                 .Append($"Comfort: {Comfort}");
                return sb.ToString();
            }
            else
                return "none";
        }

        public bool RemoveFish(IFish fish)
        {
           bool removed = Fish.Remove(fish);
            return removed;
        }
    }
}
