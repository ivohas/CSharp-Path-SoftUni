using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            Dictionary<string, double> departments = new Dictionary<string, double>();

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                double price = double.Parse(inputArgs[1]);
                string department = inputArgs[2];

                Employee employee = new Employee(name, price, department);
                employees.Add(employee);

                if (!employees.Any(x => x.Department = department))
                {

                }
                departments.Add(department, price);
            }

            double minSalary = double.MaxValue;
            double maxSalary = double.MinValue;

            string mostPaid = string.Empty;
            string leastPaid = string.Empty;

            foreach (Employee employee1 in employees)
            {
                if (employee1.Salary > maxSalary)
                {
                    mostPaid = $"{employee1.Name} {employee1.Salary:f2}";
                }
                else if (employee1.Salary < minSalary)
                {
                    leastPaid = $"{employee1.Name} {employee1.Salary:f2}";
                }
            }

            double highestAverageSalary;

            foreach (var department1 in departments.Values)
            {

            }
        }
    }

    class Employee
    {
        public string Name { get; set; }

        public double Salary { get; set; }

        public string Department { get; set; }

        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
    }
}
