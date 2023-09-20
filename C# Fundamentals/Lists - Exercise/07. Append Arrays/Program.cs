using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main()
        {
            List<string> numbersString = Console.ReadLine().Split('|').Reverse().ToList();

            numbersString.RemoveAll(x => x == "|");

            String listOfNumbers = String.Join(" ", numbersString);
            listOfNumbers = Regex.Replace(listOfNumbers, " {2,}", " ");

            Console.WriteLine(listOfNumbers.Trim());
        }
    }
}
