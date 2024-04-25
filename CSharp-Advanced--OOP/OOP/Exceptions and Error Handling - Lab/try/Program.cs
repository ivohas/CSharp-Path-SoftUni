using System;
using System.Text;

namespace trye
{
    internal class Program
{
    static void Main(string[] args)
    {
            int sum = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string kinti = cmdArgs[1];

                string substromg = kinti.Substring(1, kinti.Length - 4);
                sum += int.Parse(substromg);
            }
            Console.WriteLine(sum);
    }
}
}
