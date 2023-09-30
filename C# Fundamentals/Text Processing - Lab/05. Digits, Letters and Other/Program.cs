using System;
using System.Linq;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Console.WriteLine(text.Where(x => char.IsDigit(x)).ToArray());
            Console.WriteLine(text.Where(x => char.IsLetter(x)).ToArray());
            Console.WriteLine(text.Where(x => !char.IsLetterOrDigit(x)).ToArray());
        }
    }
}
