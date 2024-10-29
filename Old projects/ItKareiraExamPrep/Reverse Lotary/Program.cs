namespace Reverse_Lotary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            var combination = new int[k];

            GenereteCombination(combination, n, 0);
        }

        private static void GenereteCombination(int[] combinations, int n, int index)
        {
            if (combinations.Length == index)
            {
                Console.WriteLine(String.Join('.', combinations));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                combinations[index] = i;
                GenereteCombination(combinations, n, index+1);
            }
        }
    }
}