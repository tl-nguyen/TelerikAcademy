namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Company.SampleDataGenerator.DataGenerators.Contracts;

    internal class EmployeeDataGenerator : DataGenerator
    {
        public EmployeeDataGenerator(IRandomDataGenerator random, CompanyEntities db, int count)
            : base(random, db, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Employees");

            var departmentIds = this.Database.Departments.Select(d => d.Id).ToList();

            var managerCount = (int)(Count * 0.05);
            var managerIds = new int[managerCount];

            for (var i = 1; i < managerCount; i++)
            {
                managerIds[i] = i;
            }

            // Add employees
            for (var i = 0; i < this.Count; i++)
            {
                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithRandomLenght(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLenght(5, 20),
                    DepartmentId = departmentIds[this.Random.GetRandomNumber(0, departmentIds.Count - 1)],
                    YearSalary = this.Random.GetRandomNumber(50000, 200000)
                };

                if (i > managerCount)
                {
                    var managerId = managerIds[this.Random.GetRandomNumber(1, managerIds.Count() - 1)];

                    var idExisted = getManagerId(managerId);

                    if (idExisted != null)
                    {
                        employee.ManagerId = idExisted;
                    }
                }

                this.Database.Employees.Add(employee);

                if (i % 50 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            this.Database.SaveChanges();

            Console.WriteLine("\nEmployees Added!");
        }

        public int? getManagerId(int managerId)
        {
            int id = this.Database.Employees.Where(e => e.Id == managerId).Select(e => e.Id).FirstOrDefault();

            return id;
        }
    }
}
