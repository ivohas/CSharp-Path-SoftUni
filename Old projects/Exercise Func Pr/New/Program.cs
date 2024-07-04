using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New
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
                        List<string> newNames = new List<string>();
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
                        List<string> newNAmes = new List<string>();
                        int length = int.Parse(token[2]);
                        foreach (var item in list)
                        {
                            if (item.Length != length)
                            {
                                newNAmes.Add(item);
                            }
                        }
                        list = newNAmes;
                    }
                }


                if (token[0] == "Double")
                {
                    if (token[1] == "StartsWith")
                    {
                        string start = token[2];
                        var newlist = new List<string>();
                        foreach (var item in list)
                        {
                            newlist.Add(item);
                            if (item.StartsWith(start))
                            {
                                newlist.Add(item);
                            }
                        }
                        list=newlist;
                    }
                    else if (token[1] == "EndsWith")
                    {
                        var newList = new List<string>();
                        string end = token[2];
                        foreach (var item in list)
                        {
                            newList.Add(item);
                            if (item.EndsWith(end))
                            {
                                newList.Add(item);
                            }
                        }
                        list=newList;

                    }
                    else if (token[1] == "Length")
                    {
                        var newList = new List<string>();
                        int lenght = int.Parse(token[2]);
                        foreach (string item in list)
                        {
                            newList.Add(item);
                            if (item.Length == lenght)
                            {
                                newList.Add(item);
                            }
                        }
                        list = newList;
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
