using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace countUpperCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isCapita = (string x) => x.Length > 0 && char.IsUpper(x[0]);
            Console.WriteLine(string.Join("\r\n ",Console.ReadLine().Split().Where(x=>isCapita(x)).ToArray()));
           
            
            
               
        }
    }
}
