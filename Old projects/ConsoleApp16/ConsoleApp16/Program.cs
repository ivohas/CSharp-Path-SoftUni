using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dic = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var list = Console.ReadLine().Split(' ').ToList();
                string name = list[0];
                double grade = double.Parse(list[1]);
                if (!dic.ContainsKey(name))
                { 
                    dic.Add(name, new List<double>());
                }
                dic[name].Add(grade);

            }
            foreach (var name in dic.Keys )
            {
                List<double> grade = dic[name];
                string graders = string.Join(" ", grade.Select(x => x.ToString("f2")));
                decimal avr = (decimal)(grade.Average());
              
                Console.WriteLine($"{name} -> {graders} (avg: {avr:f2})");
            }
            
        }
    }
}
