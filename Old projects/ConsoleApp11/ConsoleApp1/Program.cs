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
            List<int> integers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> stack = new Stack<int>();
            foreach (var item in integers)
            {
                stack.Push(item);
            }
            string command = Console.ReadLine();
            List<string> comm = command.Split().ToList();
            command.ToLower();
            comm[0].ToLower();
            while (command != "end")
            {

                if (comm[0] == "add")
                {
                    int firstInt = int.Parse(comm[1]);
                    int secondInt = int.Parse(comm[2]);
                    stack.Push(firstInt);
                    stack.Push(secondInt);

                }
                else if (comm[0] == "remove")
                {
                    int indexesToRemove = int.Parse(comm[1]);
                    int lenght = stack.Count();
                    if (lenght >= indexesToRemove)
                    {
                        for (int i = 0; i < indexesToRemove ; i++)
                        {
                            stack.Pop();

                        }


                    }
                }

                command = Console.ReadLine();
                command.ToLower();
                comm = command.Split().ToList();
               

            }
            int sum = 0;
            var arr= stack.ToArray().Sum();
            Console.WriteLine($"Sum: {arr}");
        }
    }
}
