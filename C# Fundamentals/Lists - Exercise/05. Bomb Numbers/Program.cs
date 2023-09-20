using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string[] cmdArgs = Console.ReadLine().Split(' ');

            int bombNumber = int.Parse(cmdArgs[0]);
            int bombRange = int.Parse(cmdArgs[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    for (int j = i - bombRange; j <= i + bombRange; j++)
                    {
                        if (j < 0 || j >= numbers.Count)
                        {
                            continue;
                        }
                        numbers[j] = 0;
                    }
                }
            }            
            Console.WriteLine(numbers.Sum());
        }
    }
}
