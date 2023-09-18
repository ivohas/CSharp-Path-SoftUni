using System;
using System.Collections.Generic;

namespace _07._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> students = new Dictionary<string, double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(studentName))
                {
                    students[studentName] = ((students[studentName] + studentGrade) / 2);
                }
                else
                {
                    students[studentName] = studentGrade;
                }

            }

            foreach (var student in students)
            {
                if (student.Value >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value:F2}");
                }
            }
        }
    }
}
