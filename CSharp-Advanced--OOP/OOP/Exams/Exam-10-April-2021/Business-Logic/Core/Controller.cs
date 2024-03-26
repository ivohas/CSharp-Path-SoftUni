using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new HashSet<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            this.aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();

            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            this.decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IFish fish;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            string aquariumType = aquarium?.GetType().Name.Replace("Aquarium", string.Empty);
            string fishTypeName = fish?.GetType().Name.Replace("Fish", string.Empty);
            if (aquariumType == fishTypeName)
            {
                aquarium.AddFish(fish);
            }
            string output = aquariumType != fishTypeName ? OutputMessages.UnsuitableWater :
                String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            return output;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal value = 0;
            foreach (IDecoration decoration in aquarium.Decorations)
            {
                value += decoration.Price;
            }
            decimal priceSum =
                aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return String.Format(OutputMessages.AquariumValue, aquariumName, priceSum);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(f => f.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(f => f.Name == aquariumName);
            IDecoration decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium?.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Aquarium aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
