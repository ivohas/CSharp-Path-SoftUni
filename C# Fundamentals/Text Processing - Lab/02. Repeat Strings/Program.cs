using System;
using System.Text;

namespace _02._Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);


            StringBuilder wordsArr = new StringBuilder();

            foreach (var word in words)
            {

                int count = word.Length;
                
                for (int i = 0; i < count; i++)
                {
                    wordsArr.Append(word);
                }
            }

            Console.WriteLine(wordsArr);
        }
    }
}
