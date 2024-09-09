using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadotkalsnata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int n = int.Parse(Console.ReadLine());
            while (n < 20 || n > 1)
            {
                n = int.Parse(Console.ReadLine());

            } 

            int[] array = new int[n];
            int[] secondArray = new int[n];
            int kratno = 0;
            int contains = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                if (array[i] % 3 == 0)
                {
                     sum += array[i];
                }
            }
            for (int i = 0; i<n; i++) 
            {
                secondArray[i]=int.Parse(Console.ReadLine());
                int num= secondArray[i];
                do
                {
                    int cifra=num%10;
                    if (cifra == 3 ) 
                    { 
                        contains++;
                        break;
                    }
                    num = num / 10;

                } while (n!=0);
            }
            Console.WriteLine(kratno);
            Console.WriteLine(contains);


        }
    }
}
