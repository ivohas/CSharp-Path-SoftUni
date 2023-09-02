using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            char c;
            string text;
            for (int i = start; i <= end; i++)
            {
                c = (char)i;
                text = c.ToString();
                Console.Write(text + " ");
            }
        }
    }
}
