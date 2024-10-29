using System.Text;

namespace Elements
{
    internal class Program
    {
        private static string[] elements;
        private static int k;
        private static string[] combinations;
        private static List<List<string>> allCombinations = new List<List<string>>();
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());
            var priorityEl = Console.ReadLine().Split().ToList();

            combinations = new string[k];
            Combinations(0, 0);

            foreach (var combination in allCombinations)
            {
                List<string> priorty = combination
                    .Where(x => priorityEl.Contains(x))
                    .OrderBy(x => priorityEl.IndexOf(x))
                    .ToList();

                List<string> nonPriority = combination
                    .Where(x => !priorityEl.Contains(x))
                    .ToList();

                priorty.AddRange(nonPriority);

                Console.WriteLine(string.Join(" ", priorty));
            }
        }

        private static void Combinations(int combIndex, int elementsStartIndex)
        {
            if (combIndex >= combinations.Length)
            {
                allCombinations.Add(combinations.ToList());
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[combIndex] = elements[i];
                Combinations(combIndex + 1, i + 1);
            }
        }
    }
}