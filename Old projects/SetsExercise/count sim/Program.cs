using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace count_sim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            char[] chars = a.ToCharArray();
            SortedDictionary<char,int> dict=new SortedDictionary<char,int>();
            foreach (char item in chars)
            {
                if(!dict.ContainsKey(item))
                    dict.Add(item, 0);
                dict[item]++;
            }
            foreach (var item in dict) 
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
