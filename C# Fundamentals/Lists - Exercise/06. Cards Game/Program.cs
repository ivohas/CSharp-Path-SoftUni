using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main()
        {
            List<int> firstPlayerDeck = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondPlayerDeck = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (true)
            {
                if (firstPlayerDeck[0] > secondPlayerDeck[0])
                {
                    firstPlayerDeck.Add(firstPlayerDeck[0]);
                    firstPlayerDeck.Add(secondPlayerDeck[0]);
                }
                else if (firstPlayerDeck[0] < secondPlayerDeck[0])
                {
                    secondPlayerDeck.Add(secondPlayerDeck[0]);
                    secondPlayerDeck.Add(firstPlayerDeck[0]);
                }

                firstPlayerDeck.Remove(firstPlayerDeck[0]);
                secondPlayerDeck.Remove(secondPlayerDeck[0]);

                int winnerSum = 0;

                if (firstPlayerDeck.Count == 0)
                {
                    winnerSum = secondPlayerDeck.Sum();
                    Console.WriteLine($"Second player wins! Sum: {winnerSum}");
                    break;
                }
                else if (secondPlayerDeck.Count == 0)
                {
                    winnerSum = firstPlayerDeck.Sum();
                    Console.WriteLine($"First player wins! Sum: {winnerSum}");
                    break;
                }
            }
        }
    }
}
