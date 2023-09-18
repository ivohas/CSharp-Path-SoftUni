using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> companies = new Dictionary<string, HashSet<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] companyArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string companyName = companyArgs[0];
                string employeeId = companyArgs[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new HashSet<string>() { employeeId });
                }
                else
                {
                    companies[companyName].Add(employeeId);
                }

            }
            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
