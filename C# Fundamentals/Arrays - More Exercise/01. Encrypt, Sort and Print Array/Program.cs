using System;
using System.Linq;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char[] vowelsFound = new char[vowels.Length];

            double[] values = new double[n];

            double sum = 0;
            string word = string.Empty;

            for (int Names = 0; Names < n; Names++)
            {
                word = Console.ReadLine();

                for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
                {
                    if (vowels.Contains(word[letterIndex]))
                    {
                        sum = sum + (int)word[letterIndex] * word.Length;
                    }
                    else
                    {
                        sum = sum + (int)word[letterIndex] / word.Length;
                    }
                }
                values[Names] = sum;
                sum = 0;
            }
            Array.Sort(values);
            Console.WriteLine(String.Join(Environment.NewLine, values));
        }
    }
}