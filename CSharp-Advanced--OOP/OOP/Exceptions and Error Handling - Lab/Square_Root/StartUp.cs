using System;

namespace Square_Root
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                Sqrt(number);
                Console.WriteLine(Sqrt(number));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine("Invalid number.");
                throw ex;
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        public static double Sqrt(double value)
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException("Invalid number.");
            }
            return Math.Sqrt(value);
        }
    }
}
