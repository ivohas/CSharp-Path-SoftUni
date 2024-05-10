using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    public class StartUp
    {
        static void Main()
        {
            List<string> IDs = new List<string>();
            
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', '-');
                string id = cmdArgs[cmdArgs.Length - 1];

                IDs.Add(id);
            }

            string fakeID = Console.ReadLine();
            foreach (string id in IDs)
            {
                string idCheckSubstring = id.Substring(id.Length - fakeID.Length);
                if (idCheckSubstring == fakeID)
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
