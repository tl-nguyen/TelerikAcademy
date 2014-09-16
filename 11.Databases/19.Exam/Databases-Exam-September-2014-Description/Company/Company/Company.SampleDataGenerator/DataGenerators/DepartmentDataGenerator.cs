namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    
    using Company.Data;
    using Company.SampleDataGenerator.DataGenerators.Contracts;


    internal class DepartmentDataGenerator : DataGenerator
    {
        public DepartmentDataGenerator(IRandomDataGenerator random, CompanyEntities db, int count)
            : base(random, db, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Departments");

            var departmentsToBeAdded = new HashSet<string>();

            while (departmentsToBeAdded.Count != this.Count)
            {
                departmentsToBeAdded.Add(Random.GetRandomStringWithRandomLenght(10, 50));
            }

            var index = 0;
            foreach (var department in departmentsToBeAdded)
            {
                var newDepartment = new Department
                {
                    Name = department
                };

                this.Database.Departments.Add(newDepartment);

                index++;

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }
            Console.WriteLine("\nDepartments Added!");
        }
    }
}
