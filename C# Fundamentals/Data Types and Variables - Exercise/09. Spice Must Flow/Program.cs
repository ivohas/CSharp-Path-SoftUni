using System;

namespace _09._Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int spiceProduced = 0;
            int dayCounter = 0;
            if (startingYield < 100)
            {

            }
            else
            {
                while (startingYield >= 100)
                {
                    spiceProduced += startingYield - 26;
                    startingYield -= 10;
                    dayCounter++;
                }

                spiceProduced -= 26;

            }
            Console.WriteLine(dayCounter);
            Console.WriteLine(spiceProduced);
        }
    }
}
