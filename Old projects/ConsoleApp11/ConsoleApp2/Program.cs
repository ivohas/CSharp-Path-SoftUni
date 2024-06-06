using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expresion = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < expresion.Length; i++)
            {
                char ch = expresion[i];
                if (ch == '(')
                {
                    stack.Push(i);
                }
                if (ch==')')
                {
                    int startInd = stack.Pop();
                    int endInd = i+1;
                    string sub= expresion.Substring(startInd, endInd - startInd);
                    Console.WriteLine(sub);
                }
            }

        }
    }
}
