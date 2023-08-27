using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string kind = "";

            if (age >= 0 && age <= 2)
            {
                kind = "baby";
            }
            else if (age > 2 && age < 14)
            {
                kind = "child";
            }
            else if (age > 13 && age < 20)
            {
                kind = "teenager";
            }
            else if (age > 19 && age < 66)
            {
                kind = "adult";
            }
            else if (age >= 6)
            {
                kind = "elder";
            }
            Console.WriteLine(kind);
        }
    }
}
