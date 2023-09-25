using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);



                if (DoesStudentExist(students, cmdArgs[0], cmdArgs[1]))
                {
                    Student existingStudent = GetExistingStudent(students, cmdArgs[0], cmdArgs[1]);

                    existingStudent.Age = int.Parse(cmdArgs[2]);
                    existingStudent.HomeTown = cmdArgs[3];
                }
                else
                {
                    Student student = new Student
                    {
                        FirstName = cmdArgs[0],
                        LastName = cmdArgs[1],
                        Age = int.Parse(cmdArgs[2]),
                        HomeTown = cmdArgs[3]
                    };
                    students.Add(student);
                }


                command = Console.ReadLine();
            }

            string homeTownFilter = Console.ReadLine();
            List<Student> filteredStudents = students.FindAll(student => student.HomeTown == homeTownFilter);

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        static bool DoesStudentExist(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }

        static Student GetExistingStudent(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return student;
                }
            }

            return null;
        }
    }
}
