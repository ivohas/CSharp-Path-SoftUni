namespace AnimalFarm
{
    using System;
    using AnimalFarm.Models;
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Chicken chicken = new Chicken(name, age);
                Console.WriteLine(
                    $"Chicken {chicken.Ime} (age {chicken.Godini}) can produce {chicken.productionPerDay} eggs per day.");
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
        }
    }
}
