using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack  <int> stack = new Stack<int>();
            int push = array[0];
            int pop = array[1];
            int contains = array[2];
            for (int i = 0; i < push; i++)
            {
                stack.Push(list[i]);

            }
            for (int i = 0; i < pop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(contains))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    List<int> liste = new List<int>();
                    int a = int.MaxValue;
                    foreach (var item in stack)
                    {
                        liste.Add(item);
                    }
                    for (int i = 0; i < stack.Count; i++)
                    {
                        if (a >liste[i])
                        {
                            a = liste[i];
                        }
                       
                    } Console.WriteLine(a);

                }
                else
                {
                    Console.WriteLine(0);
                }

            }
        }
    }
}
