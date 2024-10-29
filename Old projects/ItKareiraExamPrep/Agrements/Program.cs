namespace Agrements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(nums.Max()- nums.Min());
        }
    }
}