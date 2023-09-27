using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            string pattern = @"@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*?\:(\d+)[^\@\-\!\:\>]*?\!(?<attackType>[A|D]){1}\![^\@\-\!\:\>]*?\-\>(\d+)";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
                string decryptedMessage = DecryptMessage(encryptedMessage);

                Match orderInfo = Regex.Match(decryptedMessage, pattern);
                if (orderInfo.Success)
                {
                    string planet = orderInfo.Groups["planet"].Value;
                    string attackType = orderInfo.Groups["attackType"].Value;

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planet);
                    }
                    else if (attackType == "D")
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }

            PrintOutput(attackedPlanets, destroyedPlanets);
        }

        static void PrintOutput(List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets.OrderBy(n => n))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets.OrderBy(n => n))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
        static string DecryptMessage(string encryptedMessage)
        {
            StringBuilder decryptedMessage = new StringBuilder();

            int decryptionKey = GetDectyptionKey(encryptedMessage);

            foreach (char currChar in encryptedMessage)
            {
                char decryptedChar = (char)(currChar - decryptionKey);
                decryptedMessage.Append(decryptedChar);
            }

            return decryptedMessage.ToString();
        }
        static int GetDectyptionKey(string encryptedMessage)
        {
            string decryptPattern = "[starSTAR]{1}";
            MatchCollection matches = Regex.Matches(encryptedMessage, decryptPattern, RegexOptions.IgnoreCase);

            return matches.Count;
        }
    }
}
