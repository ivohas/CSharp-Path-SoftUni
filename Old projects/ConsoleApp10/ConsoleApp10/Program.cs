using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command = Console.ReadLine();
            List<string> arguments = new List<string>();

            while (command != "Travel")
            {
                arguments = command.Split(':').ToList();
                switch (arguments[0])
                {
                    case "Add Stop":
                        int index = int.Parse(arguments[1]);
                        string stringToAdd = arguments[2];
                        if (index >= 0 && index <= stops.Length)
                        {
                           stops= stops.Insert(index, stringToAdd);
                            

                        }
                        
                        break;
                    case "Remove Stop":
                        int indexToStart = int.Parse(arguments[1]);
                        int indexToEnd = int.Parse(arguments[2]);
                        if (indexToStart >= 0 && indexToStart <= stops.Length &&
                            indexToEnd >= 0 && indexToEnd <= stops.Length)
                        {
                            int count = indexToEnd + 1 - indexToStart;
                            if (indexToStart+count<=stops.Length)
                            { 
                                stops= stops.Remove(indexToStart, count);

                            }
                          
                            
                        }
                        break;
                    case "Switch":
                        string old=arguments[1];
                        string newOne= arguments[2];
                        if (stops.Contains(old))
                        {
                           stops= stops.Replace(old, newOne); 
                            
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine(stops);
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
