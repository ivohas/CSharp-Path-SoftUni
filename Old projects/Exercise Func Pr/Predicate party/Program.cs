using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate_party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().ToList();
            string command = "";
            while (command != "Party!")
            {
                command = Console.ReadLine();
                if (command == "Party!")
                {
                    break;
                }
                string[] token = command.Split();
               

                if (token[0] == "Remove")
                {
                    if (token[1] == "StartsWith")
                    {
                        List<string> result = new List<string>();
                        string start = token[2];
                        foreach (var item in list)
                        {
                            if (!item.StartsWith(start))
                            {
                                result.Add(item);
                            }
                            

                        }
                        list = result;
                    }
                    else if (token[1] == "EndsWith")
                    {
                        List<string>newNames = new List<string>();
                        string end = token[2];
                        foreach (var item in list)
                        {
                            if (!item.EndsWith(end))
                            {
                                newNames.Add(item);
                            }
                        }
                        list = newNames;
                    }
                    else if (token[1] == "Length")
                    {
                        int length = int.Parse(token[2]);
                        foreach (var item in list)
                        {
                            if (item.Length == length)
                            {
                                list.Remove(item);
                            }
                        }
                    }
                }


                if (token[0] == "Double")
                {

                    if (token[1] == "StartsWith")
                    {
                        string start = token[2];
                        foreach (var item in list)
                        {
                            if (item.StartsWith(start))
                            {
                                string name = item;

                                list.Add(name);
                            }
                        }
                    }
                    else if (token[1] == "EndsWith")
                    {
                        string end = token[2];
                        foreach (var item in list)
                        {
                            if (item.EndsWith(end))
                            {
                                list.Add(item);
                            }
                        }
                    }
                    else if (token[1] == "Length")
                    {
                        int length = int.Parse(token[2]);
                        foreach (var item in list)
                        {
                            if (item.Length == length)
                            {
                                string name = item;
                                list.Add(name);
                            }
                        }
                    }







                }
            }
            if (list.Count > 0)
            {
                Console.WriteLine(string.Join(", ", list) + " are going to the party!");

            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
    }
}