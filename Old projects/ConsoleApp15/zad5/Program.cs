using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string,string>>();
            for (int i = 0; i < n; i++)
            {
                List<string> list = new List<string>();
                string continent = list[0];
                string country = list[1];
                string capital = list[2];
                if (dict.ContainsKey(continent))
                {
                    dict[continent].Add(country);
                    dict[country].Add(capital);
                }
                else
                {
                    dict[continent] = new Dictionary<string, string>[country];
                }
               
            }
        }
    }
}
