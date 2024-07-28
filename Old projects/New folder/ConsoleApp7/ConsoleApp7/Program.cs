using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cvete= Console.ReadLine();
            var broi= int.Parse (Console.ReadLine());
            var biodjet= double.Parse (Console.ReadLine());
            double c=0;
            double roses = 5;
            double dalia = 3.8;
            double lale = 2.8;
            double n = 3;double no= 0;
            double gladiola = 2.5;
            switch (cvete)
            {
                case "Roses":
                    c = roses * broi;
                    if (broi>=80)
                    {
                      no  = c - c / 10;
                    }
                    break;
                case "Dahlias":
                    c = dalia * broi;
                    if (broi>=90)
                    {
                            no= c - c / 10; 
                    }
                    break;
                case "Tulips":
                    c=lale * broi;
                    if (broi>=80)
                    {
                        no = c - c / 100 * 15;
                    }
                    break;
                case "Narcissus":
                    c=n* broi;
                    if (broi<=120)
                    {
                        no =c+(c / 100 * 15);
                    }
                    break;
                case "Gladiolus":
                    c= gladiola * broi;
                    if (broi<=80)
                    {
                        no = c + c / 5;
                    }
                    break;
                    default:
                    break;
            }
            
            if (biodjet >no)
            {
               double a = (biodjet - c);
                Console.WriteLine($"Hey you have a great garden with {broi} {cvete} and {a} leva left.");
            }
            else
            {
                double a = c - biodjet;
                Console.WriteLine("Not enough money, you need " + a + " leva more.");
            }





        }
    }
}
