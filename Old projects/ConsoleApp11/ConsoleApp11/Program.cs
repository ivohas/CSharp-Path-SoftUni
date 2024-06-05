using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s= Console.ReadLine();
            Stack<char> strings = new Stack<char>();
            foreach (var ch in s)
            {
                strings.Push(ch);
            }
            while (strings.Count>0)
            {
                Console.Write(strings.Pop());
            }
        }
    }
}
