using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numBadGrades = int.Parse(Console.ReadLine());

            double sumGrades = 0;
            int problems = 0;
            string lastProblem = string.Empty;
            int badGradesCounter = 0;
            string currProblem = Console.ReadLine();

            while (currProblem != "Enough")
            {
                lastProblem = currProblem;
                double currGrade = double.Parse(Console.ReadLine());

                sumGrades += currGrade;
                problems++;

                if (currGrade <= 4.00)
                {
                    badGradesCounter++;
                }
                if (badGradesCounter == numBadGrades)
                {
                    Console.WriteLine("You need a break, {0} poor grades.", badGradesCounter);
                    return;
                }
                currProblem = Console.ReadLine();
            }
            Console.WriteLine("Average score: {0:f2}", sumGrades / problems);
            Console.WriteLine("Number of problems: {0}", problems);
            Console.WriteLine("Last problem: {0}", lastProblem);
        }
    }
}
