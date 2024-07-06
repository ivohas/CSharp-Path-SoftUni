using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadachazaochenka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5=0;
            for (int i = 0; i < n; i++)
            {
                int num=int.Parse(Console.ReadLine());
                if (num > 0 && num < 200)
                {
                    p1++;
                }
                else if (num < 399)
                {
                    p2++;
                }
                else if (num < 599)
                {
                    p3++;
                }
                else if (num < 799)
                {
                    p4++;
                }
                else if (num < 1000)
                {
                    p5++;
                }
            }
            double underTwoH = ((double)p1 / n) * 100;
            Console.WriteLine($"{underTwoH:F2}% ");
            double underFourH = ((double)p2 / n) * 100;
            Console.WriteLine($"{underFourH:F2}% ");
            double underSixHundred = ((double)p3 / n) * 100;
            Console.WriteLine($"{underSixHundred:F2}% ");
            double underSixH = ((double)p4 / n) * 100;
            Console.WriteLine($"{underSixH:F2}% ");
            double aboverEH = ((double)p1 / n) * 100;
            Console.WriteLine($"{aboverEH :F2}% ");
        }
    }
}
