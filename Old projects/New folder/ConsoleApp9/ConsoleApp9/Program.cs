using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        { int h=0;
            int m=0;
            int a=0;
            do
            {
                m++;
                if (m==60)
                {
                    h++;
                    a = m % 60;
                    Console.WriteLine(h+":"+a);
                }
                Console.WriteLine(h+":"+m);
            } while (h != 24);
        }
    }
}
