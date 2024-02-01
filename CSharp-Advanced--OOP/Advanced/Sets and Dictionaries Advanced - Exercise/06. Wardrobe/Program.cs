using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Color
    {
        public string Name { get; set; }
        public List<Dress> dresses { get; set; }
        public Color(string name, List<Dress> dresses)
        {
            this.Name = name;
            this.dresses = dresses;
        }

    }

    class Dress
    {
        public string dressName { get; set; }
        public int Count { get; set; }
        public bool Found { get; set; }

        public Dress(string name, int count, bool found)
        {
            this.dressName = name;
            this.Count = count;
            this.Found = found;
        }

        public override string ToString()
        {
            return $"* {dressName} - {Count}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Color> wardrobe = new List<Color>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] colorDresses = Console.ReadLine().Split(" -> ");
                string[] dressesArray = colorDresses[1].Split(',');
                string color = colorDresses[0];
                List<Dress> dresses = new List<Dress>();

                if (wardrobe.Contains(wardrobe.Find(x => x.Name == color)))
                {
                    AddDress(wardrobe, color, dressesArray);
                }
                else
                {
                    AddColor(wardrobe, color, dressesArray);
                }
            }

            string[] cmdArgs = Console.ReadLine().Split(' ');
            (string colorToFind, string dressToFind) = (cmdArgs[0], cmdArgs[1]);

            if (wardrobe.Contains(wardrobe.Find(c => c.Name.Equals(colorToFind))))
            {
                FindFoundDress(wardrobe, colorToFind, dressToFind);
            }

            ShowWardrobe(wardrobe);
        }

        private static void AddDress(List<Color> wardrobe, string color, string[] dressesArray)
        {
            Color currColor = wardrobe.Find(x => x.Name == color);
            for (int j = 0; j < dressesArray.Length; j++)
            {
                string currDressFromCycle = dressesArray[j];
                if (currColor.dresses.Contains(currColor.dresses.Find(d => d.dressName.Equals(currDressFromCycle))))
                {
                    Dress currDress = currColor.dresses.Find(d => d.dressName.Equals(currDressFromCycle));
                    currDress.Count++;
                }
                else
                {
                    Dress dress = new Dress(currDressFromCycle, 1, false);
                    currColor.dresses.Add(dress);
                }
            }
        }
        private static void AddColor(List<Color> wardrobe, string color, string[] dressesArray)
        {
            Color currColor = wardrobe.Find(x => x.Name == color);
            List<Dress> dressList = new List<Dress>();
            for (int j = 0; j < dressesArray.Length; j++)
            {
                string currDressFromCycle = dressesArray[j];
                if (dressList.Contains(dressList.Find(x => x.dressName == currDressFromCycle)))
                {
                    Dress currDress = dressList.Find(x => x.dressName == currDressFromCycle);
                    currDress.Count++;
                }
                else
                {
                    Dress currDress = new Dress(currDressFromCycle, 1, false);
                    dressList.Add(currDress);
                }
            }
                Color colorClass = new Color(color, dressList);
            wardrobe.Add(colorClass);
        }

        private static void FindFoundDress(List<Color> wardrobe, string colorToFind, string dressToFind)
        {
            Color currColor = wardrobe.Find(c => c.Name.Equals(colorToFind));
            if (currColor.dresses.Contains(currColor.dresses.Find(d => d.dressName.Equals(dressToFind))))
            {
                Dress currDress = currColor.dresses.Find(d => d.dressName.Equals(dressToFind));
                currDress.Found = true;
            }
        }

        private static void ShowWardrobe(List<Color> wardrobe)
        {
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Name} clothes:");
                foreach (var dress in color.dresses)
                {
                    Console.Write(dress);
                    if (dress.Found)
                    {
                        Console.WriteLine(" (found!)");
                    }
                    else Console.WriteLine();
                }
            }
        }

    }
}
