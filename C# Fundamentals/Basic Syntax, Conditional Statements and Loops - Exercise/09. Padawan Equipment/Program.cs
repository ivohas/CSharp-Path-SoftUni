using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input
            double budget = double.Parse(Console.ReadLine());
            int studentsQ = int.Parse(Console.ReadLine());

            //prices
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());

            //Quantity
            double lightsabers = studentsQ + Math.Ceiling(0.1 * studentsQ);
            int belts = studentsQ;
            double robes = studentsQ - studentsQ / 6;

            //final prices
            double lightsabersFinal = lightsabers * lightsabersPrice;
            double beltsFinal = belts * beltsPrice;
            double robesFinal = robes * robesPrice;
            double cost = lightsabersFinal + beltsFinal + robesFinal;

            if (budget >= cost)
            {
                Console.WriteLine($"The money is enough - it would cost {cost:f2}lv.");
            }
            else
            {
                Console.WriteLine($" John will need {(cost - budget):f2}lv more.");
            }

        }
    }
}
