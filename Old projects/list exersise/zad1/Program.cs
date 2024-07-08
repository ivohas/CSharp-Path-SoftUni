using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity= int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            do
            {
                string[] parts = command.Split();
                switch (parts[0])
                {
                    case "Add":
                        int num= int.Parse(parts[1]);
                        int place= list.Count+1;
                        list.Insert (place, num);
                        break;
                    default:
                        int numToAdd= int.Parse(parts[0]);
                        for (int i = 0; i <= list.Count ; i++)
                        {
                            int numCap = capacity - list[i];
                            if (numCap>=numToAdd)
                            {
                                int num1 = list[i] + numToAdd;
                                list.RemoveAt (i);
                                list.Insert (i, num1);
                            }

                        }
                        
                        break;
                }

                command = Console.ReadLine();

            } while (command != "end");
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
