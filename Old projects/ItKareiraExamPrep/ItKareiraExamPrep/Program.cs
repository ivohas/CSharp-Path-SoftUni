using System;

class Program
{
    static void Main()
    {
        // Вход: четем K и N от конзолата
        int K = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        // Място за съхранение на текущата конфигурация
        int[] combination = new int[K];

        // Рекурсивен метод за генериране на всички възможни комбинации
        GenerateCombinations(combination, N, 0);
    }

    static void GenerateCombinations(int[] combination, int N, int index)
    {
        if (index == combination.Length)
        {
            // Когато стигнем до края, отпечатваме текущата конфигурация
            Console.WriteLine(string.Join(".", combination));
            return;
        }

        // Генерираме всички възможни числа от 1 до N за текущата позиция
        for (int i = 1; i <= N; i++)
        {
            combination[index] = i;
            GenerateCombinations(combination, N, index + 1);
        }
    }
}
