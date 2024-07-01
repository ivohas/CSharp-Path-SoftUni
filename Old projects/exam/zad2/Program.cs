using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> numbers = Console.ReadLine()
                .Split(' ').ToList();

            string[] command = Console.ReadLine()
                .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);


            while (command[0] != "Finish")
            {
                switch (command[0])
                {
                    case "Add":
                        numbers.Add(command[1]);
                        break;
                    case "Remove":
                        if (numbers.Contains(command[1])) 
                        {
                            numbers.Remove(command[1]);
                            break;
                        }
                        break;
                    case "Replace":
                        if (numbers.Contains(command[1]))
                        {
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numbers[i] == command[1])
                                {
                                    numbers[i] = command[2];
                                    break;
                                }
                            }
                        }
                        break;
                    case "Collapse":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (int.Parse(numbers[i]) < int.Parse(command[1]))
                            {
                                numbers.Remove(numbers[i]);
                            }
                        }
                        break;
                }
                command = Console.ReadLine().Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
