using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EmployeesInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            

            TelerikAcademyEntities ctx = new TelerikAcademyEntities();

            using (ctx)
            {
                // n+1 query problem
                var employeesWithoutInclude = ctx.Employees;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                foreach (var employee in employeesWithoutInclude)
                {
                    
                    Console.WriteLine("Name: {0}\nDepartment: {1}\nTown: {2}",
                                            employee.FirstName + " " + employee.LastName,
                                            employee.Department.Name,
                                            employee.Address.Town.Name);
                }

                stopwatch.Stop();
                Console.WriteLine("Time : {0}", stopwatch.Elapsed);

                stopwatch.Reset();
                stopwatch.Start();

                var employeesWithInclude = ctx.Employees.Include("Department").Include("Address").Include("Address.Towns");

                foreach (var employee in employeesWithoutInclude)
                {
                    Console.WriteLine("Name: {0}\nDepartment: {1}\nTown: {2}",
                                            employee.FirstName + " " + employee.LastName,
                                            employee.Department.Name,
                                            employee.Address.Town.Name);
                }
                stopwatch.Stop();
                Console.WriteLine("Time : {0}", stopwatch.Elapsed);
            }
        }
    }
}
