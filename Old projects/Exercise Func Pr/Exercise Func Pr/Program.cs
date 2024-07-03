using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_Func_Pr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] token = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int minVAlue = token[0];
            int maxVAlue = token[1];
            string command = Console.ReadLine();
            List<int> list = new List<int>();
            if (command == "even")
            {
                for (int i = minVAlue; i <= maxVAlue; i++)
                {
                    if (i % 2 == 0)
                    {
                        list.Add(i);
                    }
                }
            }
            else
            {
                for (int i = minVAlue; i <= maxVAlue; i++)
                {
                    if (i % 2 != 0)
                    {
                        list.Add(i);
                    }
                }
            }
            Console.WriteLine(String.Join(" ",list));

        }
    }
}
