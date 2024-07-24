using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();double strana = double.Parse(Console.ReadLine());  ;double b; double razmer;
;            switch (a)
            {
                case "square":
                    razmer = strana * strana;
                    Console.WriteLine(razmer);
                    break;
                case "rentagular":
                    b= double.Parse(Console.ReadLine());
                    razmer = (strana * b) ;
                    Console.WriteLine(razmer);
                    break;
                case "circle":
                    razmer = strana * Math.PI  ;
                    Console.WriteLine(razmer );
                    break;
                case "triagle":
                    b = double.Parse(Console.ReadLine());
                    razmer = (strana * b)/2;
                    Console.WriteLine(razmer);
                    break;
                    default:break;
            }
        }
    }
}
