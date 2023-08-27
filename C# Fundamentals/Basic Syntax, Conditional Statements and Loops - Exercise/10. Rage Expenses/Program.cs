using System;

namespace _10._Rage_Expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());

            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboarPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());


            double sum = 0;

            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    sum += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    sum += mousePrice;
                }
                if (i % 6 == 0)
                {
                    sum += keyboarPrice;
                }
                if (i % 12 == 0)
                {
                    sum += displayPrice;
                }
            }

            Console.WriteLine($"Rage expenses: {sum:f2} lv.");

        }
    }
}
