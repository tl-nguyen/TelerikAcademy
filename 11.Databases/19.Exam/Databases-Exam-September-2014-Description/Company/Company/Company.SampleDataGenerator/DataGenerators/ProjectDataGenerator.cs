namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using Company.Data;
    using Company.SampleDataGenerator.DataGenerators.Contracts;

    internal class ProjectDataGenerator : DataGenerator
    {
        public ProjectDataGenerator(IRandomDataGenerator random, CompanyEntities db, int count)
            : base(random, db, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Projects");

            var employeeIds = this.Database.Employees.Select(d => d.Id).ToList();

            // adding projects
            for (var i = 0; i < this.Count; i++ )
            {
                // adding project
                var newProject = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLenght(5, 50)
                };

                // adding employees for the project
                var employeesCount = this.Random.GetRandomNumber(2, 10);
                var employeesInProject = new HashSet<int>();

                while(employeesInProject.Count != employeesCount)
                {
                    employeesInProject.Add(employeeIds[this.Random.GetRandomNumber(0, employeeIds.Count -1)]);
                }

                foreach (var employeeInProject in employeesInProject)
                {
                    var startingDate = new DateTime(
                                            this.Random.GetRandomNumber(2000, 2014),
                                            this.Random.GetRandomNumber(1, 12),
                                            this.Random.GetRandomNumber(1,28));
                    
                    var endingDate = startingDate.AddMonths(this.Random.GetRandomNumber(1, 24));

                    var recentEmployee = new EmployeesProject
                    {
                        EmployeeId = employeeInProject,
                        StartingDate = startingDate,
                        EndingDate = endingDate
                    };

                    newProject.EmployeesProjects.Add(recentEmployee);
                }

                this.Database.Projects.Add(newProject);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nProjects Added!");
        }


    }
}
