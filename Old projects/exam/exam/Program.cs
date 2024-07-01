using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flavour = double.Parse(Console.ReadLine());
            double egg = double.Parse(Console.ReadLine());
            double apron = double.Parse(Console.ReadLine());
            double freePackages = students / 5;
            freePackages = Math.Round(freePackages);
            double needs = apron * (students + (Math.Ceiling(students * 0.20))) + (egg * 10 * (students)) + (flavour * (students - freePackages));
            if (budget - needs >= 0)
            {
                Console.WriteLine($"Items purchased for {needs:f2}$.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(budget - needs):f2}$ more needed.");
            }
        }
    }
}
