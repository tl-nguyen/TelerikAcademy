namespace Company.SampleDataGenerator
{
    using System.Collections.Generic;

    using Company.Data;
    using Company.SampleDataGenerator.DataGenerators;
    using Company.SampleDataGenerator.DataGenerators.Contracts;

    class Program
    {
        static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();

            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new DepartmentDataGenerator(random, db, 100),
                new EmployeeDataGenerator(random, db, 5000),
                new ProjectDataGenerator(random, db, 1000),
                new ReportDataGenerator(random, db, 250000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
