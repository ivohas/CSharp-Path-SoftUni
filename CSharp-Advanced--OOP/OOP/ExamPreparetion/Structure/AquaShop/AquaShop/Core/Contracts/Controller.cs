using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
       private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new HashSet<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType== "FreshwaterAquarium"||aquariumType== "SaltwaterAquarium")
            {
               
                aquarium= new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType== "Ornament")
            {
                decoration = new Ornament();
            }
            else if(decorationType=="Plant")
            {
               decoration= new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            
            var aquarium = aquariums.FirstOrDefault(x=>x.Name==aquariumName);
            IFish fish=null;
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
                throw new InvalidOperationException("Invalid fish type.");
            }
            var aqueriumType = aquarium?.GetType().Name.Replace("Aquarium", string.Empty);
            var fishstr = fishType.Replace("Fish", string.Empty);
            if (aqueriumType == fishstr)
            {
                aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";

            }
            else
            {
                return "Water not suitable.";
            }
            
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal price;
            price =aquarium.Fish.Sum(x => x.Price);
            price+=aquarium.Decorations.Sum(x => x.Price);
            return $"The value of Aquarium {aquariumName} is {price:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
           var aquarium= aquariums.FirstOrDefault(x=>x.Name==aquariumName);
            
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed,  aquarium.Fish.Count());
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
           var aquaerium= aquariums.FirstOrDefault(x=>x.Name==aquariumName);
            IDecoration decoration = decorations.FindByType(decorationType);
            if (decoration==null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            
            aquaerium?.Decorations.Add(decoration);
           
            decorations.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aqua in aquariums) {
                sb.Append(aqua.GetInfo());
            
            }
            return sb.ToString();
        }
    }
}
