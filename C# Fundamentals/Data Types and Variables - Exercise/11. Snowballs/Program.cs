using System;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double maxValue = 0;

            string bestSnowball = string.Empty;

            for (int i = 0; i < n; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

                double value = Math.Pow(snow / time, quality);

                if (value >= maxValue)
                {
                    maxValue = value;
                    bestSnowball = ($"{snow} : {time} = {value} ({quality})");
                }
            }
            
            Console.WriteLine(bestSnowball);
        }
    }
}
