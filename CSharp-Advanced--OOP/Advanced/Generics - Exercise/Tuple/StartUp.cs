using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var fulLName = $"{personInfo[0]} {personInfo[1]}";
            var city = $"{personInfo[2]}";

            var nameAndBear = Console.ReadLine().Split();
            var name = nameAndBear[0];
            var litters = int.Parse(nameAndBear[1]);

            var numbersInput = Console.ReadLine().Split();
            var intNum = int.Parse(numbersInput[0]);
            var doubleNum = double.Parse(numbersInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fulLName, city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, litters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);
            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
