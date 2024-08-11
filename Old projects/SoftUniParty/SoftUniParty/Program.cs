using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names= new HashSet<string>();
            var reservanion = new HashSet<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command=="END")
                {
                    break;
                }
                if (command=="PARTY")
                {
                    foreach (var item in names)
                    {
                        reservanion.Add(item);
                    }
                    names.Clear();
                }
                names.Add(command);

            }
            foreach (var item in names)
            {
                if (reservanion.Contains(item))
                {
                    names.Remove(item);
                }
                
            }
            int lenght= names.Count;
            Console.WriteLine(names);
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
