using System;

class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();

        if (word.Length != 2)
        {
            Console.WriteLine("No FuFu");
            return;
        }

        List<string> words = new List<string>();

        for (char i = 'a'; i <= 'z'; i++)
        {
            for (char j = 'a'; j <= 'z'; j++)
            {
                if (i != j)
                {
                    words.Add($"{i}{j}");
                }
            }
        }


        if (words.Contains(word))
        {
            Console.WriteLine(words.IndexOf(word) + 1);
        }
        else
        {
            Console.WriteLine("No FuFu");
        }
    }
}
