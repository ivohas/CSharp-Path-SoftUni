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
        {
            var words = Console.ReadLine().Split( ).ToArray();
            List<string> list = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                int lenght=words[i].Length;
                string word = words[i];
                for (int a = 1; a <=lenght; a++)
                {
                    list.Add(word);
                }

            }
            Console.WriteLine(string.Join("",list));
        }
    }
}
