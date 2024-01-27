using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main()
        {
            ListIyterator<string> listy = null;

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                string cmd = tokens[0];

                if (cmd == "Create")
                {
                    listy = new ListIyterator<string>(tokens.Skip(1).ToArray());
                }
                else if (cmd == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (cmd == "Print")
                {
                    listy.Print();
                }
                else if (cmd == "PrintAll")
                {
                    listy.PrintAll();
                }
                else if (cmd == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }

                command = Console.ReadLine();
            }
        }
    }
}