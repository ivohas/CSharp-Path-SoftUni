using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guestInvites = new HashSet<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "PARTY")
                {
                    break;
                }

                guestInvites.Add(command);

            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                    break;
                if(guestInvites.Contains(command))
                guestInvites.Remove(command);

            }

            Console.WriteLine(guestInvites.Count);
            foreach (string guest in guestInvites)
            {
                if (char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }

            foreach (string guest in guestInvites)
            {
                if (!char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
