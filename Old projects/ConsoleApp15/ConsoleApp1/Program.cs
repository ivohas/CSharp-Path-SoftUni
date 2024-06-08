using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string studentName = "";
            double grade = 0;
            var nums= new List<double>();
            var dict= new Dictionary<string, List<double> >();
            for (int i = 0; i < n; i++)
            {
                var list = Console.ReadLine().Split().ToList();
                var name = list[0];
                studentName = name;
                grade = double.Parse(list[1]);
                
               
                if (dict.ContainsKey(studentName))
                {
                      dict[studentName].Add(grade);
                }
                else
                {

                    dict.Add(studentName, new List<double>());
                    dict[studentName].Add(grade);
                }
            }
            foreach (var item in dict )
            {
                var currentGrades = string.Join(" ", item.Value) ;
                
                
                Console.WriteLine($"{item.Key} -> {currentGrades}({item.Value.Averege():f2}) ");
            }

        }

        private static void ReadStAndGr(string studentName, double grade)
        {
            var list = Console.ReadLine().Split().ToList();
            var name=list[0];
            studentName = name;
            grade = double.Parse(list[1]);
        }
    }
}
