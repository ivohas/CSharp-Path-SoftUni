using System;
using System.Globalization;

namespace SpacecraftProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double length = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double averageAstronautHeight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double spacecraftVolume = width * length * height;
            double astronautRoomVolume = (averageAstronautHeight + 0.4) * 2 * 2;
            int astronautsCount = (int)(spacecraftVolume / astronautRoomVolume);

            if (astronautsCount >= 3 && astronautsCount <= 10)
            {
                Console.WriteLine($"The spacecraft holds {astronautsCount} astronauts.");
            }
            else if (astronautsCount < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
