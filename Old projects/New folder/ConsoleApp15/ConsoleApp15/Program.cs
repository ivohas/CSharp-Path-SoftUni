using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int .Parse(Console.ReadLine());
            int apartaments = int .Parse(Console.ReadLine());
            for (int i = 1; i < floors; i++)
            {
                if (i % 2 == 0)
                {
                    for (int a = apartaments ; a <= 0 ; a--)
                    {
                        
                        Console.Write($"A{i}{a}");Console.WriteLine();
                    }
                }
                else
                {
                    for (int a = 1; a <= apartaments; a++)
                    {
                        Console.Write($"O{i}{a}");
                        Console.WriteLine();
                    }
                }
            }
            for (int a = 0; a < apartaments ; a++)
            {
                
                Console.Write($"L{floors}{a}");Console.WriteLine();
            }
        }
    }
}
