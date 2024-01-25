using System;
using System.Collections.Generic;
using System.Linq;

namespace Swap
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);
            var elToCommpare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CountOfGreaterElements(list, elToCommpare));
        }
    }
}
