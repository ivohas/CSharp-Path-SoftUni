using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            do
            {
                string[] parts = command.Split();
                switch (parts[0])
                {
                    case "Delete":
                        int remove= int.Parse(parts[1]);
                        list.Remove(remove);
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i]==remove)
                            {
                                list.Remove(remove);
                            }
                        }
                        break;
                    case "Insert":
                        int element = int.Parse(parts[1]);
                        int position= int.Parse(parts[2]);
                        list.Insert(position, element);
                        break;
                }

                command = Console.ReadLine();

            } while(command!="end");
            Console.WriteLine(String.Join(" ",list));
        }
    }
}
