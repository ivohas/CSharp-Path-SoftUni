using System;

namespace _08._Beer_Kegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKeg = "";
            double maxVolume = 0;
            for (int i = 0; i < n; i++)
            {
                string KegName = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;
                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    biggestKeg = KegName;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
