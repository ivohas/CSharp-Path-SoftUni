using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Vavedi chas:");
            //  Console.WriteLine("Vavedi minuti:");
            // int ch = int.Parse(Console.ReadLine());
            // int min=int.Parse(Console.ReadLine());
            // int m = min + 15;
          //  int a;
          //  if (min>=60)
           // {
           //     ch++;
               //  a= min%60;
          //  }
           // Console.WriteLine(ch+":"+a);
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            if (a==b&&a==c)
            {
                Console.WriteLine("yes");
            }
            else { Console.WriteLine("no"); }
        }
    }
}
