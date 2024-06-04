using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); ; char first, second, third; first = 'a';
            second = 'a';
            third = 'a';
            if (n == 3)
            {
                do
                {

                    Console.Write(first);
                    Console.Write(second);
                    Console.WriteLine(third);
                    third += (char)(1);
                    if (third == 'd')
                    {
                        third = 'a';
                        second += (char)1;
                    }
                    if (second == 'd')
                    {
                        second = 'a';
                        first += (char)1;
                    }
                } while (third != 'c' || second != 'c' || first != 'c');
                Console.Write(first);
                Console.Write(second);
                Console.WriteLine(third);

            }
            if (n == 2) 
            {
                do
                {

                    Console.Write(first);
                    Console.Write(second);
                    Console.WriteLine(third);
                    third += (char)(1);
                    if (third == 'c')
                    {
                        third = 'a';
                        second += (char)1;
                    }
                    if (second == 'c')
                    {
                        second = 'a';
                        first += (char)1;
                    }
                } while (third != 'b' || second != 'b' || first != 'b');
                Console.Write(first);
                Console.Write(second);
                Console.WriteLine(third);
            }
            if (n == 4)
            {
                do
                {

                    Console.Write(first);
                    Console.Write(second);
                    Console.WriteLine(third);
                    third += (char)(1);
                    if (third == 'e')
                    {
                        third = 'a';
                        second += (char)1;
                    }
                    if (second == 'e')
                    {
                        second = 'a';
                        first += (char)1;
                    }
                } while (third != 'd' || second != 'd' || first != 'd');
                Console.Write(first);
                Console.Write(second);
                Console.WriteLine(third);
            }
            if (n == 1) 
            {
                Console.WriteLine("aaa");
                Console.WriteLine("bbb");
                Console.WriteLine("ccc");
            }

            if (n == 5)
            {
                do
                {

                    Console.Write(first);
                    Console.Write(second);
                    Console.WriteLine(third);
                    third += (char)(1);
                    if (third == 'f')
                    {
                        third = 'f';
                        second += (char)1;
                    }
                    if (second == 'f')
                    {
                        second = 'a';
                        first += (char)1;
                    }
                } while (third != 'e' || second != 'e' || first != 'e');
                Console.Write(first);
                Console.Write(second);
                Console.WriteLine(third);
            }
            if (n == 6)
            {
                do
                {

                    Console.Write(first);
                    Console.Write(second);
                    Console.WriteLine(third);
                    third += (char)(1);
                    if (third == 'g')
                    {
                        third = 'g';
                        second += (char)1;
                    }
                    if (second == 'g')
                    {
                        second = 'a';
                        first += (char)1;
                    }
                } while (third != 'f' || second != 'f' || first != 'f');
                Console.Write(first);
                Console.Write(second);
                Console.WriteLine(third);
            }

        }
    }
}


