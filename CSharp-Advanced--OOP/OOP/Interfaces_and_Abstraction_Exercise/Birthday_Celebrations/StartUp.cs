using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    public class StartUp
    {
        static void Main()
        {
            List<string> birthDates = new List<string>();
            
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ', '-');
                string birthdate = cmdArgs[cmdArgs.Length - 1];

                birthDates.Add(birthdate);
            }

            birthDates.RemoveAll(x => String.IsNullOrEmpty(x));
            string birthDateToFind = Console.ReadLine();
            
            foreach (string birthDate in birthDates)
            {
                string idCheckSubstring = birthDate.Substring(birthDate.Length - birthDateToFind.Length);
                if (idCheckSubstring == birthDateToFind)
                {
                    Console.WriteLine(birthDate);
                }
            }
        }
    }
}
