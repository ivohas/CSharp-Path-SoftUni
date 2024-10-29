using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Функция за броене на "завъртанията" (инверсии) в дадена пермутация
    static int CountInversions(int[] perm)
    {
        int inversions = 0;
        int n = perm.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (perm[i] > perm[j])
                {
                    inversions++;
                }
            }
        }
        return inversions;
    }

    // Функция за генериране на пермутациите
    static IEnumerable<int[]> GetPermutations(int[] numbers)
    {
        return Permute(numbers, 0, numbers.Length - 1);
    }

    static IEnumerable<int[]> Permute(int[] numbers, int left, int right)
    {
        if (left == right)
        {
            yield return (int[])numbers.Clone();
        }
        else
        {
            for (int i = left; i <= right; i++)
            {
                Swap(ref numbers[left], ref numbers[i]);
                foreach (var perm in Permute(numbers, left + 1, right))
                {
                    yield return perm;
                }
                Swap(ref numbers[left], ref numbers[i]); // Възстановяване на първоначалния ред
            }
        }
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Main(string[] args)
    {
        // Четене на входа
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // Броим пермутациите със четен брой завъртания (сладурски)
        int cutePermutationsCount = 0;

        foreach (var perm in GetPermutations(numbers))
        {
            int inversions = CountInversions(perm);
            if (inversions % 2 == 0)
            {
                cutePermutationsCount++;
            }
        }

        // Извеждаме броя на сладурските пермутации
        Console.WriteLine(cutePermutationsCount);
    }
}
