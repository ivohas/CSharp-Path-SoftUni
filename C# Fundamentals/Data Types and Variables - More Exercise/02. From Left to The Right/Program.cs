using System;
using System.Numerics;

namespace _02._From_Left_to_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                BigInteger sum = 0;
                string[] tokens = Console.ReadLine().Split();

                BigInteger left = BigInteger.Parse(tokens[0]);
                BigInteger right = BigInteger.Parse(tokens[1]);

                if (left > right || left == right)
                {
                    if (left > 0)
                    {
                        while (left > 0)
                        {
                            sum += left % 10;
                            left /= 10;
                        }
                    }
                    else
                    {
                        while (left < 0)
                        {
                            sum += left % 10;
                            left /= 10;
                        }
                    }

                    Console.WriteLine(sum);
                }
                else if (right > left)
                {
                    if (right > 0)
                    {
                        while (right > 0)
                        {
                            sum += right % 10;
                            right /= 10;
                        }
                    }
                    else
                    {
                        while (right < 0)
                        {
                            sum += right % 10;
                            right /= 10;
                        }
                    }
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
