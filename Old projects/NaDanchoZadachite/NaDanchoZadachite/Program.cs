using System;
using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int locationsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < locationsCount; i++)
        {
            double expectedAverageGoldPerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int days = int.Parse(Console.ReadLine());

            double totalGold = 0;

            for (int day = 0; day < days; day++)
            {
                double goldPerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                totalGold += goldPerDay;
            }

            double averageGoldPerDay = totalGold / days;

            if (averageGoldPerDay >= expectedAverageGoldPerDay)
            {
                Console.WriteLine($"Good job! Average gold per day: {averageGoldPerDay:f2}.");
            }
            else
            {
                double neededGold = expectedAverageGoldPerDay - averageGoldPerDay;
                Console.WriteLine($"You need {neededGold:f2} gold.");
            }
        }
    }
}
