  namespace SoftUni;
  using SoftUni.Data;
    using SoftUni.Models;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using System.Runtime.InteropServices.ComTypes;
using System.Globalization;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();
        string result = GetEmployeesInPeriod(dbContext);
        Console.WriteLine(result);
    }
    // Problem 3
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var employees = context.Employees
              .OrderBy(e => e.EmployeeId).
              Select(e => new
              {
                  e.FirstName,
                  e.LastName,
                  e.MiddleName,
                  e.JobTitle,
                  e.Salary
              })
              .ToArray();
        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }
        return sb.ToString().TrimEnd();


    }
    // Problem 4
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.Salary > 50000)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .OrderBy(e => e.FirstName);
        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }
        return sb.ToString
            ().TrimEnd();
    }

    //  Problem 5

    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) {
        var employees = context.Employees.
            Where(e => e.Department.Name == "Research and Development")
             .Select(e => new
             {
                 e.FirstName,
                 e.LastName,
                 e.Department,
                 e.Salary
             })
             .OrderBy(e => e.Salary).
             ThenByDescending(e => e.FirstName);

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
        }
        return sb.ToString().Trim();
    }
    // Problem 6
    public static string AddNewAddressToEmployee(SoftUniContext context) { 
      
      Address newAddress = new Address() { 
       AddressText= "Vitoshka 15",
       TownId = 4
      };
       // context.Addresses.Add(newAddress);
        Employee? employee = context.Employees.
            FirstOrDefault(e => e.LastName == "Nakov");
        employee.Address = newAddress;
        context.SaveChanges();

        string [] employeesAddress = context.Employees
            .OrderByDescending(e=>e.AddressId)
            .Take(10)
            .Select(e=>e.Address!.AddressText)
            .ToArray();

        return String.Join(Environment.NewLine, employeesAddress);
    }

    // Problem 7 

    public static string GetEmployeesInPeriod(SoftUniContext context) 
    {
        StringBuilder sb = new StringBuilder();
        var employeesWithProjects = context.Employees
            //.Where(e => e.EmployeesProjects
            //    .Any(ep => ep.Project.StartDate.Year >= 2001 &&
            //               ep.Project.StartDate.Year <= 2003))
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                    })
                    .ToArray()
            })
            .ToArray();

        foreach (var e in employeesWithProjects)
        {
            sb
                .AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                sb
                    .AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }
    // Problem 8 
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var employeeWithAddress = context.Addresses
            .Select(a => new
            {
                Address = a.AddressText,
                Town= a.Town.Name,
                employees = a.Employees.Count
            }).OrderByDescending(a=> a.employees)
            .ThenBy(a=>a.Town)
            .ThenBy(a=>a.Address)
            .Take(10)
            .ToArray();
        
        StringBuilder sb = new StringBuilder();
        foreach (var a in employeeWithAddress)
        {
            sb.AppendLine($"{a.Address}, {a.Town} - {a.employees} employees");
        }
        return sb.ToString().Trim();
    }
    // Problem 9 

    public static string GetEmployee147(SoftUniContext context) {
       
        StringBuilder sb = new StringBuilder();

        Employee e = context.Employees
            .FirstOrDefault(e => e.EmployeeId == 147)!;

        sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

        foreach (EmployeeProject ep in e.EmployeesProjects.OrderBy(p => p.Project.Name))
        {
            sb.AppendLine($"{ep.Project.Name}");
        }

        return sb.ToString().TrimEnd();

    }
}

