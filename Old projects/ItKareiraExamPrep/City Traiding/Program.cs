namespace City_Traiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cities = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = cities.Length;

            if (count == 0)
            {
                Console.WriteLine("0");
            }
            else if (count == 1)
            {
                Console.WriteLine(cities[1]);
            }

            int[] cost = new int[count];
            cost[0] = cities[0];
            cost[1] = cities[1];

            for (int i = 2; i < count; i++)
            {
                cost[i] = Math.Min(cost[i - 2], cost[i - 1]) + cities[i];
            }

            Console.WriteLine(Math.Min(cost[count - 1], cost[count - 2]));
        }
    }
}