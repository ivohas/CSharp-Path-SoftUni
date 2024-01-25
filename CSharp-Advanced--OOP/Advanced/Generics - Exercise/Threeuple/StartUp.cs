using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var fulLName = $"{personInfo[0]} {personInfo[1]}";
            var street = $"{personInfo[2]}";
            var city = $"{personInfo[3]}";

            var rusiOtVievo = Console.ReadLine().Split();
            var name = rusiOtVievo[0];
            var litters = int.Parse(rusiOtVievo[1]);
            var drunkOrNot = rusiOtVievo[2];
            bool isDrunk = false;
            if (drunkOrNot == "drunk")
            {
                isDrunk = true;
            }

            var anotherInput = Console.ReadLine().Split();
            var accountant = anotherInput[0];
            var doubleNum = double.Parse(anotherInput[1]);
            var bankAcc = anotherInput[2];

            Tuple<string, string, string> firstThreeuple = new Tuple<string, string, string>(fulLName, street, city);
            Tuple<string, int, bool> secondThreeuple = new Tuple<string, int, bool>(name, litters, isDrunk);
            Tuple<string, double, string> thirdThreeuple = new Tuple<string, double, string>(accountant, doubleNum, bankAcc);
            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
