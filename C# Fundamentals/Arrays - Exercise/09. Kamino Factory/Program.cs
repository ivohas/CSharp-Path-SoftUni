using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main()
        {
            int dnaLength = int.Parse(Console.ReadLine());

            int[] bestSample = new int[dnaLength];
            int leftmostIndex = dnaLength;
            int bestSampleSequenseLenght = 0;
            int bestSampleSum = 0;
            int bestSampleNumber = 1;

            string command = Console.ReadLine();
            int sampleNum = 0;

            while (command != "Clone them!")
            {
                int[] currentSample = command.Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sampleNum++;

                int currentSequenceLenght = 0;
                int previousSequenceLenght = 0;
                int currentLongestSequence = 0;

                int leftmostIndexInCurrentArray = dnaLength;

                int currentSampleSum = 0;

                for (int i = 0; i < currentSample.Length; i++)
                {
                    if (currentSample[i] == 1)
                    {
                        currentSequenceLenght++;
                        currentSampleSum++;
                    }
                    else
                    {
                        previousSequenceLenght = currentSequenceLenght;
                        currentSequenceLenght = 0;
                    }

                    if (currentSequenceLenght > previousSequenceLenght)
                    {
                        currentLongestSequence = currentSequenceLenght;
                        leftmostIndexInCurrentArray = i - currentSequenceLenght + 1;
                    }
                }

                if (currentLongestSequence > bestSampleSequenseLenght)
                {
                    bestSampleSequenseLenght = currentLongestSequence;
                    leftmostIndex = leftmostIndexInCurrentArray;
                    bestSample = currentSample;
                    bestSampleNumber = sampleNum;
                    bestSampleSum = currentSampleSum;
                }
                else if (currentLongestSequence == bestSampleSequenseLenght)
                {
                    if (leftmostIndexInCurrentArray < leftmostIndex)
                    {
                        leftmostIndex = leftmostIndexInCurrentArray;
                        bestSampleSum = currentSampleSum;
                        bestSample = currentSample;
                        bestSampleNumber = sampleNum;
                    }
                    else if (leftmostIndex == leftmostIndexInCurrentArray)
                    {
                        if (currentSampleSum > bestSampleSum)
                        {
                            bestSampleSum = currentSampleSum;
                            bestSample = currentSample;
                            bestSampleNumber = sampleNum;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSampleNumber} with sum: {bestSampleSum}.");
            Console.WriteLine(string.Join(" ", bestSample));
        }
    }
}