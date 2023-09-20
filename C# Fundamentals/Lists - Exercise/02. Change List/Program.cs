using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command;
            int index = 0;
            int number = 0;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] splitedCmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (splitedCmdArgs.Length == 2)
                {
                    number = int.Parse(splitedCmdArgs[1]);
                    numbers.RemoveAll(x => x == number);
                }
                else if (splitedCmdArgs.Length == 3)
                {
                    number =  int.Parse((splitedCmdArgs[1]));
                    index = int.Parse(splitedCmdArgs[2]);
                    numbers.Insert(index, number);
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
