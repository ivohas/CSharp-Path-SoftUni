using System;
using System.Collections.Generic;
using System.Linq;

namespace Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(' ').ToList();

            string input;
            int movesCounter = 0;


            while ((input = Console.ReadLine()) != "end")
            {
                int[] guessIndexes = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstIndex = guessIndexes[0];
                int secondIndex = guessIndexes[1];

                if (elements.Count != 0)
                {
                    movesCounter++;
                    if (firstIndex < 0 || secondIndex < 0)
                    {
                        Console.WriteLine("Invalid input! Adding additional elements to the board");
                        string fail = $"-{movesCounter}a";
                        elements.Insert(elements.Count / 2, fail);
                        elements.Insert(elements.Count / 2, fail);
                        continue;
                    }

                    else if (firstIndex != secondIndex && firstIndex < elements.Count && secondIndex < elements.Count)
                    {

                        if (elements[firstIndex] == elements[secondIndex])
                        {
                            Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");
                            string firstNumber = elements[firstIndex];
                            string secondNumber = elements[secondIndex];

                            elements.Remove(firstNumber);
                            elements.Remove(secondNumber);
                            continue;
                        }
                        else if (elements[firstIndex] != elements[secondIndex])
                        {
                            Console.WriteLine("Try again!");
                            continue;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }


            if (elements.Count != 0)
            {
                Console.WriteLine($"Sorry you lose :(");
                Console.WriteLine(String.Join(" ", elements));
            }
            else
            {
                Console.WriteLine($"You have won in {movesCounter} turns!");
                return;
            }
        }
    }
}
