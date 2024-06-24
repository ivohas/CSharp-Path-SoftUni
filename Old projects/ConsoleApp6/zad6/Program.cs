using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6
{
    internal class Program
    {
        private static object command;

        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            string command=Console.ReadLine();
           
            do
            { string [] token= command.Split();
                string action = token[0];
                switch (action)
                {
                    case "Add":
                        int a = int.Parse(token[1]);
                        list.Add(a);
                        break;
                    case "Remove":
                        int b = int.Parse(token[1]);
                        list.Remove(b);
                        break;
                    case "RemoveAt":
                        int c = int.Parse(token[1]);
                        list.RemoveAt(c);
                        break;
                    case "Insert":
                        int first = int.Parse(token[1]);
                        int second = int.Parse(token[2]);
                        list.Insert( second,first);
                        break;
                        default:
                        break;
                }
                command = Console.ReadLine();
            }
            while(command!="end");
            Console.WriteLine(String.Join(" ",list));
        }
    }
}
