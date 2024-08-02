using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());double average;
            double a=double.Parse(Console.ReadLine());int dve=0,tri=0,four=0,five=0;
            for (int i = 1; i <= students; i++)
            {

                if (a>=2&&a <= 2.99)
                {
                    dve++;
                }
                else if (a <= 3.99)
                {
                    tri++;
                }
                else if (a <= 4.99)
                {
                    four++;
                }
                else { five++; }
            }  a = double.Parse(Console.ReadLine());average =+ a;
            double b = (double)dve /  students * 100;
            double c = (double)tri / students * 100;
            double d = (double)four / students * 100; 
            double f=(double)five / students * 100;
            average = average / students;
            Console.WriteLine("Top students: "+f);
            Console.WriteLine("Between 4.00 and 4.99: "+ d);
            Console.WriteLine("Between 3.00 and 3.99: "+ c);
            Console.WriteLine("Fail: "+ b);
            Console.WriteLine("Average: "+ average );

        }
    }
}
