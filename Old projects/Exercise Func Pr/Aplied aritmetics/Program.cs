using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplied_aritmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {   List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, int> add = x => x + 1;
            Func<int,int> multiply = x => x * 2;
            Func<List<int>, List<int>> substraact = lists => lists.Select(number =>number-=1).ToList();
            
            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {

                    case "add":
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i] =list[i]+1;
                        }
                        break;
                    case "multiply":
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i] = list[i] *2;
                        }
                        break;
                    case "subtract":
                       list=substraact(list);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", list));
                        break;
                    default:
                        break;


                }
                command = Console.ReadLine();
            }

        }
    }
}
