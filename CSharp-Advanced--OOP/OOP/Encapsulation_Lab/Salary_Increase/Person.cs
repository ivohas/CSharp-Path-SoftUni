using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            decimal bonus = Salary * percentage / 100;

            if (Age < 30)
            {
                Salary += bonus / 2;
            }
            else
            {
                Salary += bonus;
            }
        }
    }
}
