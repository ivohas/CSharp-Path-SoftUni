using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Четене на броя на клечките
        int N = int.Parse(Console.ReadLine());

        // Списък със зависимости - графа
        List<int>[] graph = new List<int>[N];
        for (int i = 0; i < N; i++)
        {
            graph[i] = new List<int>();
        }

        // Четене на зависимостите
        string input;
        int[] indegree = new int[N]; // Масив за броя на входящите ребра (клечки лежащи върху дадена клечка)

        while ((input = Console.ReadLine()) != "hopstop")
        {
            string[] parts = input.Split();
            int first = int.Parse(parts[0]);
            int second = int.Parse(parts[1]);

            // Добавяме зависимостта в графа: първата клечка лежи върху втората
            graph[first].Add(second);
            indegree[second]++;
        }

        // Списък за всички възможни резултати
        List<string> results = new List<string>();

        // Подготовка на масив за текущите възможни клечки за махане (с 0 входящи ребра)
        List<int> availableSticks = new List<int>();

        // Намираме всички клечки, които нямат зависимости (т.е. 0 входящи ребра)
        for (int i = 0; i < N; i++)
        {
            if (indegree[i] == 0)
                availableSticks.Add(i);
        }

        // Сортираме клечките по възходящ ред за стартиране с най-малката
        availableSticks.Sort();

        // Стартираме топологичното сортиране
        TopologicalSort(graph, indegree, availableSticks, new List<int>(), results, N);

        // Отпечатваме всички резултати
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    static void TopologicalSort(List<int>[] graph, int[] indegree, List<int> availableSticks, List<int> currentOrder, List<string> results, int N)
    {
        // Ако сме достигнали дълбочина, равна на броя на клечките, добавяме резултата
        if (currentOrder.Count == N)
        {
            results.Add(string.Join(" -> ", currentOrder));
            return;
        }

        // Преглеждаме всички възможни клечки, които могат да бъдат махнати (тези с 0 входящи ребра)
        for (int i = 0; i < availableSticks.Count; i++)
        {
            int stick = availableSticks[i];

            // Добавяме клечката към текущия ред на махане
            currentOrder.Add(stick);

            // Намаляваме входящите ребра на всички клечки, от които зависи текущата
            List<int> newAvailable = new List<int>(availableSticks);
            newAvailable.RemoveAt(i);

            foreach (var dependent in graph[stick])
            {
                indegree[dependent]--;
                if (indegree[dependent] == 0)
                {
                    newAvailable.Add(dependent);
                }
            }

            // Рекурсивно извикваме сортирането за новото състояние
            newAvailable.Sort(); // Поддържаме сортиране
            TopologicalSort(graph, indegree, newAvailable, currentOrder, results, N);

            // Връщаме промените след рекурсията (backtracking)
            currentOrder.RemoveAt(currentOrder.Count - 1);

            foreach (var dependent in graph[stick])
            {
                if (indegree[dependent] == 0)
                {
                    newAvailable.Remove(dependent);
                }
                indegree[dependent]++;
            }
        }
    }
}
