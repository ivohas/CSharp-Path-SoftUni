using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace language
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string language= Console.ReadLine ();
            switch (language)
            {
                case "USA":
                case "England": Console.WriteLine("English");break;
                case "Mexico":
                case "Spain":
                case "Argentina": Console.WriteLine("Spanish");break;
                default: Console.WriteLine("unknown");break;  
            }
        }
    }
}
