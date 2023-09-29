using System;
using System.Linq;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] users = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            users = users.OrderByDescending(x => x.Length).ToArray();

            string user1 = users[0];
            string user2 = users[1];

            int equalLength = Math.Min(user1.Length, user2.Length);
            int maxLength = Math.Max(user1.Length, user2.Length);

            int sum = 0;

            for (int i = 0; i < equalLength; i++)
            {
                sum += MultiplyAsciiCode(user1[i], user2[i]);
            }

            for (int j = maxLength - 1; j >= equalLength; j--)
            {
                sum += (char)user1[j];
            }

            Console.WriteLine(sum);
        }

        static int MultiplyAsciiCode(char user1, char user2)
        {
            return (char)user1 * (char)user2;
        }
    }
}
