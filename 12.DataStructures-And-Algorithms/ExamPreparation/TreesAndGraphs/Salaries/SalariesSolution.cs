using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries
{
    class SalariesSolution
    {
        static bool[,] adjMatrix;
        static long[] employeesSalaries;
        static long gopoSalary = 0;
        static int c;

        static void Main(string[] args)
        {
            c = int.Parse(Console.ReadLine());
            adjMatrix = new bool[c, c];
            employeesSalaries = new long[c];

            for (var i = 0; i < c; i++)
            {
                string line = Console.ReadLine();

                for (var j = 0; j < c; j++)
                {
                    adjMatrix[i, j] = (line[j] == 'Y');
                }
            }

            for (var i = 0; i < c; i++)
            {
                gopoSalary += FindSalary(i);
            }

            Console.WriteLine(gopoSalary);
        }

        private static long FindSalary(int employee)
        {
            if (employeesSalaries[employee] > 0)
            {
                return employeesSalaries[employee];
            }

            long salary = 0;

            for (var i = 0; i < c; i++)
            {
                if (adjMatrix[employee, i])
                {
                    salary += FindSalary(i);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }

            employeesSalaries[employee] = salary;

            return salary;
        }
    }
}
