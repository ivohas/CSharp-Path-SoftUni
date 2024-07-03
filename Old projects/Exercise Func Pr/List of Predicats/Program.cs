using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_of_Predicats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bounder = int.Parse(Console.ReadLine());
            int[] dividers= Console.ReadLine().Split().Select(int.Parse).ToArray();
           
                List<int>list = new List<int>();
            for (int i = 1; i <= bounder; i++)
            {
                list.Add(i);
                
            }
            foreach (var item in dividers)
            {
                Func<List<int>, List<int>> div = lists => list.Where(x => x % item == 0).ToList();
                list=div(list);
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
