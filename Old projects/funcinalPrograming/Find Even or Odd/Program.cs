using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Even_or_Odd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int miBounder = int.Parse(Console.ReadLine());
            int maxBounder = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = int.MinValue; i < maxBounder; i++)
            {
                list.Add(i);
            }
            string command = Console.ReadLine();
            if (command == "odd")
            {
                list.Where(x => x % 2 != 0);
            }
            else
            {
                list.Where(x => x % 2 == 0);
            }
            Console.WriteLine(string.Join("\r\n",list));
        }
    }
}
