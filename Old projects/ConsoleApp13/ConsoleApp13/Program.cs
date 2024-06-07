using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').ToList();
                int turns= int.Parse(Console.ReadLine()) ;
           Queue<string> queue = new Queue<string>();
            foreach (var item in list)
            {
                queue.Enqueue(item);
                
            }
            while (queue.Count>=1)
            {
                string name =queue.Peek(turns);
                turns--;
            }
           
        }

        private static void Remove(List<string> list, int turns)
        {
           var lists= Console.ReadLine().Trim().Split(' ').ToList();
            while (lists.Count>1)
            {
                list.RemoveAt(turns);

            }
        }
    }
}
