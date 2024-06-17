using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int count= int.Parse(Console.ReadLine());
            int []array= new int[count];
            for (int i = 0; i < count; i++) 
            { 
               array[i]=int.Parse(Console.ReadLine());  
            }
            Array.Reverse(array);
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
