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

            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            List<int> secondlist = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int lenght = 0;
            if (secondlist.Count > list.Count)
            {
                lenght = secondlist.Count;
            }else 
            {
                lenght = list.Count;
            }
            List<int>end=new List<int>();
            for (int i = 0; i < lenght; i++)
            {
                if (i<list.Count )
                {
                    end.Add(list[i]);

                }
                if (i<secondlist.Count )
                { 
                    end.Add(secondlist[i]);

                }
               
            }
            Console.WriteLine(String.Join(" ",end));
        }
    }
}
