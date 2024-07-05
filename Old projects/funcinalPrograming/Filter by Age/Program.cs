using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            var ch = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split(',').ToArray();
                string name = token[0];
                int age = int.Parse(token[1]);
                people.Add(name, age);
            }
            string conditional = Console.ReadLine();
            int neededAge = int.Parse(Console.ReadLine());
            if (conditional == "younger")
            {
                foreach (var item in people)
                {
                    if (neededAge > item.Value)
                    {
                        ch.Add(item.Key, item.Value);
                    }



                }
            }
            else
            {
                foreach (var item in people)
                {
                    if (neededAge <= item.Value)
                    {
                        ch.Add(item.Key, item.Value);
                    }



                }
            }
            string[]com= Console.ReadLine().Split().ToArray();
            int a= com.Length;
            if (a > 1)
            {
                foreach (var item in ch)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            else 
            {
                if (com[0] == "age")
                {
                    foreach (var item in ch)
                    {
                        Console.WriteLine(item.Value);
                    }
                }
                else 
                { 
                    foreach(var item in ch) { Console.WriteLine(item.Key); }
                }
            }
        }
    }
}
