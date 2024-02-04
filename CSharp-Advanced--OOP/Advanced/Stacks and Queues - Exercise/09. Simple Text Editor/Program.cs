using System;
using System.Collections.Generic;
using System.Text;

namespace _9._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();

            Stack<string> history = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                if (command.StartsWith("1"))
                {
                    string textForAdding = command.Split()[1];
                    text.Append(textForAdding);
                    history.Push(text.ToString());

                }
                else if (command.StartsWith("2"))
                {
                    int count = int.Parse(command.Split()[1]);
                    text.Remove(text.Length - count, count);
                    history.Push(text.ToString());

                }
                else if (command.StartsWith("3"))
                {
                    int index = int.Parse(command.Split()[1]);
                    Console.WriteLine(text[index - 1]);

                }
                else if (command.StartsWith("4"))
                {
                    if (history.Count > 0)
                    {
                        history.Pop();
                        if (history.Count > 0)
                        {
                            text = new StringBuilder(history.Peek());

                        }
                        else
                        {
                            text.Clear();
                        }
                    }
                }

            }
        }
    }
}
