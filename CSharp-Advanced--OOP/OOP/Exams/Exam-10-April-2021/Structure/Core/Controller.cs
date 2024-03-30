using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations = new DecorationRepository();
        private ICollection<IAquarium> aquariums = new List<IAquarium>();
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                IAquarium aquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
                return $"Successfully added {aquariumType}.";
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                IAquarium aquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
                return $"Successfully added {aquariumType}.";
            }
            throw new InvalidOperationException("Invalid aquarium type.");
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                IDecoration decoration = new Ornament();
                decorations.Add(decoration);
                return $"Successfully added {decorationType}.";
            }
            else if (decorationType == "Plant")
            {
                IDecoration decoration = new Plant();
                decorations.Add(decoration);
                return $"Successfully added {decorationType}.";
            }
            throw new InvalidOperationException("Invalid decoration type.");
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType == "FreshwaterFish")
            {
                IFish fish = new FreshwaterFish(fishName, fishSpecies, price);
                IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
                if (aquarium.GetType().Name.Substring(0, 8) == fish.GetType().Name.Substring(0, 8) || aquarium.GetType().Name.Substring(0, 9) == fish.GetType().Name.Substring(0, 9))
                {
                    aquarium.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                return "Water not suitable.";
            }
            else if (fishType == "SaltwaterFish")
            {
                IFish fish = new SaltwaterFish(fishName, fishSpecies, price);
                IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
                if (aquarium.GetType().Name.Substring(0, 8) == fish.GetType().Name.Substring(0, 8) || aquarium.GetType().Name.Substring(0, 9) == fish.GetType().Name.Substring(0, 9))
                {
                    aquarium.AddFish(fish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                return "Water not suitable.";
            }
            throw new InvalidOperationException("Invalid fish type.");
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal priceSum = 0m;
            foreach (IFish fish in aquarium.Fish)
            {
                priceSum += fish.Price;
            }
            foreach (IDecoration decoration in aquarium.Decorations)
            {
                priceSum += decoration.Price;
            }
            return $"The value of Aquarium {aquariumName} is {priceSum:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(f => f.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (decorationType == "Ornament")
            {
                IDecoration decoration = new Ornament();
                IAquarium aquarium = aquariums.FirstOrDefault(f => f.Name == aquariumName);
                if (decorations.Remove(decoration))
                {
                    aquarium.AddDecoration(decoration);
                    return $"Successfully added {decorationType} to {aquariumName}.";
                }                
            }
            else if (decorationType == "Plant")
            {
                IDecoration decoration = new Plant();
                IAquarium aquarium = aquariums.FirstOrDefault(f => f.Name == aquariumName);
                if (decorations.Remove(decoration))
                {
                    aquarium.AddDecoration(decoration);
                    return $"Successfully added {decorationType} to {aquariumName}.";
                }
            }
            throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Aquarium aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString();
        }
    }
}
