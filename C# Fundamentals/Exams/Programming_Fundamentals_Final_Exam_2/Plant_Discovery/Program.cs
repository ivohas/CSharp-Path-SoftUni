using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5___Plant_Discovery
{
    class Plant
    {
        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<double> Rating { get; set; }

        public Plant(string name, int rarity, List<double> rating)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Rating = rating;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();
            ReadPlantsRarity(plants);

            string cmd;
            while ((cmd = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdInfo = cmd
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdInfo[0];
                string[] cmdArgs = cmdInfo[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string plantName = cmdArgs[0];

                if (cmdType == "Rate")
                {
                    double plantRating = double.Parse(cmdArgs[1]);

                    AddPlantRating(plants, plantName, plantRating);
                }
                else if (cmdType == "Update")
                {
                    int newRarity = int.Parse(cmdArgs[1]);
                    UpdatePlantRarity(plants, plantName, newRarity);
                }
                else if (cmdType == "Reset")
                {
                    ResetPlant(plants, plantName);
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant plant in plants)
            {
                if (plant.Rarity == null || plant.Rarity == 0)
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {0}; Rating: {plant.Rating.Average():f2}");
                    continue;
                }
                if (plant.Rating.Count == 0)
                {
                    Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {0:f2}");
                    continue;
                }
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Rating.Average():f2}");

            }
        }

        static void ReadPlantsRarity(List<Plant> plants)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string plantRariry = Console.ReadLine();
                string[] plantArgs = plantRariry.Split("<->");

                string plantName = plantArgs[0];
                int rarity = int.Parse(plantArgs[1]);

                plants.Add(new Plant(plantName, rarity, new List<double>()));
            }
        }

        static void AddPlantRating(List<Plant> plants, string plantName, double rating)
        {
            foreach (Plant plant in plants)
            {
                if (plant.Name == plantName)
                {
                    plant.Rating.Add(rating);
                    return;
                }
            }
            Console.WriteLine("error");
        }

        static void UpdatePlantRarity(List<Plant> plants, string plantName, int newRarity)
        {
            foreach (Plant plant in plants)
            {
                if (plant.Name == plantName)
                {
                    plant.Rarity = newRarity;
                    return;
                }
            }
            Console.WriteLine("error");
        }

        static void ResetPlant(List<Plant> plants, string plantName)
        {
            bool contains = false;
            foreach (Plant plant in plants)
            {
                if (plant.Name == plantName)
                {
                    contains = true;
                    break;
                }
            }
            if (contains == false)
            {
                Console.WriteLine("error");
                return;
            }
            plants.Find(p => p.Name.Equals(plantName)).Rating.Clear();
        }
    }
}
