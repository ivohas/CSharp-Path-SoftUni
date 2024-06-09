using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var list = Console.ReadLine().Split(' ').ToList();
                string name = list[0];
                double grade = int.Parse(list[1]);
                if (dict.ContainsKey(name))
                {
                    dict[name].Add(grade);
                }
                else
                {
                    dict[name]= new List<double>{ grade};
                }

            }
            foreach (var item in dict)
            {
                
                Console.WriteLine($"{item.Key} ->)");
            }
        }
    }
}
