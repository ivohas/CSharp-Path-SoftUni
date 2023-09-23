using System;

namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string commmand = Console.ReadLine();

            PrintDataType(commmand);
        }

        static void PrintDataType(string command)
        {
            switch (command)
            {
                case "int":
                    int integer = int.Parse(Console.ReadLine());
                    integer *= 2;
                    Console.WriteLine(integer);
                    break;
                case "real":
                    double realNumber = double.Parse(Console.ReadLine());
                    realNumber *= 1.5;
                    Console.WriteLine($"{realNumber:f2}");
                    break;
                case "string":
                    string word = Console.ReadLine();
                    Console.WriteLine($"${word}$");
                    break;
                default:
                    break;
            }
        }
    }
}
