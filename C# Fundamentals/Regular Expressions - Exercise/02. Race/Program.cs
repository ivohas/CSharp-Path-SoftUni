using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> PlayersPoints = new Dictionary<string, int>();

            string rawPlayers = Console.ReadLine();
            string[] players = rawPlayers.Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < players.Length; i++)
            {
                PlayersPoints[players[i].Trim()] = 0;
            }

            string command;
            while ((command = Console.ReadLine()) != "end of race")
            {
                StringBuilder currNameSB = new StringBuilder();
                int currNamePoints = 0;
                char[] cryptedInfo = command.ToCharArray();
                foreach (char ch in cryptedInfo)
                {
                    if (char.IsLetter(ch))
                    {
                        currNameSB.Append(ch);
                    }
                    else if (char.IsDigit(ch))
                    {
                        currNamePoints += int.Parse(ch.ToString());
                    }
                }

                string currName = currNameSB.ToString();
                if (PlayersPoints.ContainsKey(currName))
                {
                   PlayersPoints[currName] += currNamePoints;
                }
            }

            PrintWinners(PlayersPoints);
        }

        static void PrintWinners(Dictionary<string, int> PlayersPoints)
        {
            PlayersPoints = PlayersPoints.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            if (PlayersPoints.Count > 0)
            {
                Console.WriteLine($"1st place: {PlayersPoints.First().Key.Trim()}");
                PlayersPoints.Remove(PlayersPoints.Keys.First());
            }
            if (PlayersPoints.Count > 0)
            {
                Console.WriteLine($"2nd place: {PlayersPoints.First().Key.Trim()}");
                PlayersPoints.Remove(PlayersPoints.Keys.First());
            }
            if (PlayersPoints.Count > 0)
            {
                Console.WriteLine($"3rd place: {PlayersPoints.First().Key.Trim()}");
                PlayersPoints.Remove(PlayersPoints.Keys.First());
            }
        }
    }
}
