using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            for (int i = 0; i < list.Count ; i++)
            {
                if(list[i]<0)
                {
                    list.RemoveAt(i);
                    i = 0;
                }
               
               
            } list.Reverse();
            Console.WriteLine(String.Join(" ",list));
        } 
       
    }
}
