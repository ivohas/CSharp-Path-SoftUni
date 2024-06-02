using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age=int.Parse(Console.ReadLine());string type="nnpthimg";
            if (age >= 0 && age <= 2)
            {
                type = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                type = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                type = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                type = "adult";

            }
            else if (age >= 66)
            {
                type = "elder";
            }
            Console.WriteLine(type);

        }
    }
}
