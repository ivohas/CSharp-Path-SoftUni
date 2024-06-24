using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToList();
            string command = Console.ReadLine();
            List<int>listCheck= new List<int>();
            for (int i = list.Count; i >0; i-=1)
            {
                listCheck.Add(i);
            }

            do
            {
                string[] token = command.Split();
                string action = token[0];
                switch (action)
                {
                    case "Add":
                        int a = int.Parse(token[1]);
                        list.Add(a);
                        break;
                    case "Remove":
                        int b = int.Parse(token[1]);
                        list.Remove(b);
                        break;
                    case "RemoveAt":
                        int c = int.Parse(token[1]);
                        list.RemoveAt(c);
                        break;
                    case "Insert":
                        int first = int.Parse(token[1]);
                        int second = int.Parse(token[2]);
                        list.Insert(second, first);
                        break;
                    case "Contains":
                        int contains = int.Parse(token[1]);
                      bool check=  list.Contains(contains);
                        if (check)
                        {
                            Console.WriteLine("Yes");
                        }
                        else 
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        List<int>list1= new List<int>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i]%2==0)
                            {
                                list1.Add(list[i]);
                            }
                            
                        }
                        Console.WriteLine(String.Join(" ",list1));
                        break;
                    case "PrintOdd":
                        List<int>list2= new List<int>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] % 2 != 0)
                            {
                                list2.Add(list[i]);
                            }
                            
                        }
                        Console.WriteLine(String.Join(" ", list2));
                        break;
                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            sum += list[i];
                        }
                        Console.WriteLine(sum);
                        break;
                    case"Filter":
                        int numCoun = int.Parse(token[2]);
                        string coundition = token[1];
                       List<int> listOfCoun= new List<int>();
                        if (coundition == ">")
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                if(list[i]>numCoun)
                                {
                                    listOfCoun.Add(list[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ",listOfCoun));
                        }
                        else if (coundition == "<")
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i] < numCoun)
                                {
                                    listOfCoun.Add(list[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", listOfCoun));
                        }
                        else if (coundition == "<=")
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i] <= numCoun)
                                {
                                    listOfCoun.Add(list[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", listOfCoun));
                        }
                        else if (coundition == ">=") 
                        {
                            for (int i = 0; i < list.Count; i++)
                            {
                                if (list[i] >= numCoun)
                                {
                                    listOfCoun.Add(list[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", listOfCoun));
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            while (command != "end");
            int count = 0;
            for (int i = 0; i < listCheck.Count; i++)
            {
                
            if(listCheck[i]==list[i])
            {
                    count++;
              
            }

            }
            if (count==listCheck.Count )
            {
                Console.WriteLine(String.Join(" ", list));

            }
              
           
        }
    }
}
