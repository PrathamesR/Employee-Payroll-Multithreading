using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("wad", 5000, DateTime.Parse("2/5/2020"), "Electrical", "1237894560", "Delhi", 'M'));
            employees.Add(new Employee("fsd", 10000, DateTime.Parse("2/5/2020"), "Electrical", "1237894560", "Delhi", 'M'));
            employees.Add(new Employee("sdf", 5000, DateTime.Parse("2/5/2020"), "Electrical", "1237894560", "Delhi", 'F'));
            employees.Add(new Employee("fsdfd", 5000, DateTime.Parse("2/5/2020"), "Electrical", "1237894560", "Delhi", 'M'));
            employees.Add(new Employee("cds", 10000, DateTime.Parse("2/5/2020"), "Electrical", "1237894560", "Delhi", 'F'));
            employees.Add(new Employee("scv", 7000, DateTime.Parse("2/5/2020"), "Electrical", "1237894560", "Delhi", 'M'));
            employees.Add(new Employee("wad", 5000, DateTime.Parse("2/5/2020"), "Electrical", "1237894560", "Delhi", 'M'));

            DateTime startTime = DateTime.Now;
            manager.AddNewEmployee(employees);
            DateTime endTime = DateTime.Now;

            Console.WriteLine("Total Time needed for execution : " + (endTime - startTime));

            Console.ReadLine();
        }
    }
}
