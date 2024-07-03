using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string a = Console.ReadLine();

            while (a != "end")
            {
                List<string> command = a.Split().ToList();
                switch (command[0])
                {
                    case "Chat":
                        list.Add(command[1]);
                        break;
                    case "Delete":
                        for (int d = 0; d < list.Count; d++)
                        {
                            if (command[1] == list[d])
                            {
                                list.Remove(command[1]);
                                break;
                            }
                        }
                        break;
                    case "Edit":
                        if (list.Contains(command[1]))
                        {
                            for (int b = 0; b < list.Count; b++)
                            {
                                if (list[b] == command[1])
                                {
                                    list[b] = command[2];
                                    break;
                                }
                            }
                        }
                        break;
                    case "Pin":
                        for (int c = 0; c < list.Count;c++)
                        {
                            if (list[c]==command[1])
                            {
                                string pin = list[c];
                                list.RemoveAt(c);
                                list.Add(pin);
                            }

                        }
                            break;
                    case "Spam":
                        int i=0;
                        while (command[i]!=" ")
                        {
                           list.Add(command[i]);
                            i++;
                        }
                        break;
                    default:
                        break;

                }



                a = Console.ReadLine();
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
