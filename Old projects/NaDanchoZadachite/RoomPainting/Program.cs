using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int paintBoxes = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int wallpaperRolls = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double glovesPricePerPair = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double brushPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double paintPricePerBox = 21.50;
            double wallpaperPricePerRoll = 5.20;

            int glovesNeeded = (int)Math.Ceiling(wallpaperRolls * 0.35);
            int brushesNeeded = (int)Math.Floor(paintBoxes * 0.48);

            double totalPaintCost = paintBoxes * paintPricePerBox;
            double totalWallpaperCost = wallpaperRolls * wallpaperPricePerRoll;
            double totalGlovesCost = glovesNeeded * glovesPricePerPair;
            double totalBrushesCost = brushesNeeded * brushPrice;

            double totalCost = totalPaintCost + totalWallpaperCost + totalGlovesCost + totalBrushesCost;
            double deliveryCost = totalCost / 15;

            Console.WriteLine($"This delivery will cost {deliveryCost:F2} lv.");
        }
    }
}
