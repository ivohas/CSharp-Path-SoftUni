using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public  abstract class  Fish : IFish
    {
        private string name;
        private string species;      
        private decimal price;

        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }

        public string Name {
            get => this.name;
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }
                name = value;
            
            }
        }

        public string Species { 
        get => this.species;
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }
                species = value;
            }
        
        }

        public int Size {
            get;
            protected set;
        }

        public decimal Price {
            get => this.price;
            set {
                if (value<=0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }
                this.price = value;
            }
        }

        public abstract void Eat();
       
    }
}
