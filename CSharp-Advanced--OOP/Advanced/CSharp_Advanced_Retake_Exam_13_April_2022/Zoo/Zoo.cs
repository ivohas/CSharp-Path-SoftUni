using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string AddAnimal(Animal animal)
        {
            if (animal == null && animal.Species == " ")
            {
                return "Invalid animal species."; 
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Animals.Count > Capacity - 1)
            {
                return "The zoo is full.";
            }
            return $"Successfully added {animal.ToString()} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;
            string[] specs = species.Split();
            for (int i = 0; i < specs.Length; i++)
            {
                if (Animals.Any(x => x.Species.Equals(specs[i])))
                {
                    Animals.Remove(Animals.Find(a => a.Species == specs[i]));
                    count++;
                }
            }

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(x => x.Diet == diet).ToList();
        }
        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.First(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.Where(x => x.Length >= minimumLength && x.Length <= maximumLength).Count();
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
