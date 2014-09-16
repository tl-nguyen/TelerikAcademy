namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Company.SampleDataGenerator.DataGenerators.Contracts;

    internal class ReportDataGenerator : DataGenerator
    {
        public ReportDataGenerator(IRandomDataGenerator random, CompanyEntities db, int count)
            : base(random, db, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Reports");

            var employeeIds = this.Database.Employees.Select(d => d.Id).ToList();

            for (var i = 0; i < this.Count; i++)
            {
                var reportTime = new DateTime(
                                            this.Random.GetRandomNumber(2000, 2014),
                                            this.Random.GetRandomNumber(1, 12),
                                            this.Random.GetRandomNumber(1, 28));

                var newReport = new Report
                {
                    EmployeeId = employeeIds[this.Random.GetRandomNumber(0, employeeIds.Count - 1)],
                    Time = reportTime
                };

                this.Database.Reports.Add(newReport);

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
