using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    internal class Program
    {
        static void Main()
        {

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                { "shards", 0 },
                { "motes", 0 },
                { "fragments", 0 }
            };
            Dictionary<string, int> junk = new Dictionary<string, int>();
            string itemObtained = string.Empty;

            while (String.IsNullOrEmpty(itemObtained))
            {
                string materialLine = Console.ReadLine().ToLower();
                string[] materialsArr = materialLine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                ProcessInputLine(keyMaterials, junk, materialsArr, ref itemObtained);
            }

            PrintOutput(keyMaterials, junk, itemObtained);
        }

        static void ProcessInputLine(Dictionary<string, int> keyMaterials, Dictionary<string, int> junk, string[] materialsArr, ref string itemObtained)
        {
            const int minCraftMaterialQuantity = 250;
            Dictionary<string, string> craftingTable = new Dictionary<string, string>()
            {
                { "shards", "Shadowmourne" },
                { "fragments", "Valanyr" },
                { "motes", "Dragonwrath"}
            };

            for (int i = 0; i < materialsArr.Length; i += 2)
            {
                int currMaterialQuantity = int.Parse(materialsArr[i]);
                string currMaterial = materialsArr[i + 1];

                if (keyMaterials.ContainsKey(currMaterial))
                {
                    keyMaterials[currMaterial] += currMaterialQuantity;

                    if (keyMaterials[currMaterial] >= minCraftMaterialQuantity)
                    {
                        itemObtained = craftingTable[currMaterial];
                        keyMaterials[currMaterial] -= minCraftMaterialQuantity;

                        break;
                    }
                }
                else
                {
                    if (!junk.ContainsKey(currMaterial))
                    {
                        junk[currMaterial] = 0;
                    }

                    junk[currMaterial] += currMaterialQuantity;
                }
            }
        }

        static void PrintOutput(Dictionary<string, int> keyMaterialsLeft, Dictionary<string, int> junk, string itemObtained)
        {
            Console.WriteLine($"{itemObtained} obtained!");

            foreach (var kvp in keyMaterialsLeft)
            {
                string keyMaterial = kvp.Key;
                int keyMaterialQuantityLeft = kvp.Value;

                Console.WriteLine($"{keyMaterial}: {keyMaterialQuantityLeft}");
            }

            foreach (var kvp in junk)
            {
                string junkMaterial = kvp.Key;
                int junkMaterialQuantityLeft = kvp.Value;

                Console.WriteLine($"{junkMaterial}: {junkMaterialQuantityLeft}");
            }
        }
    }
}
