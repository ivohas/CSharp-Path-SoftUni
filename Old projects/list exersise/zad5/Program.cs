using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> bombPower = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] == bombPower[0])
                {
                    for (int j = 1; j <= bombPower[1]; j++)
                    {
                        if (i - j < 0)
                        {
                            break;
                        }
                        else
                        {
                            number[i - j] = 0;
                        }
                    }

                    for (int j = 1; j <= bombPower[1]; j++)
                    {
                        if (i + j > number.Count - 1)
                        {
                            break;
                        }
                        else
                        {
                            number[i + j] = 0;
                        }
                    }

                    number[i] = 0;
                }

            }

            int sum = number.Sum();
            Console.WriteLine(sum);

        }
    }
}
