namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using ToysStore.Data;

    using ToysStore.SampleDataGenerator.DataGenerators.Contracts;

    internal class ManufacturerDataGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerDataGenerator(IRandomDataGenerator random, ToysStoreEntities db, int count)
            : base(random, db, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Manufacturers");

            var manufacturersToBeAdded = new HashSet<string>();

            while(manufacturersToBeAdded.Count != this.Count)
            {
                manufacturersToBeAdded.Add(Random.GetRandomStringWithRandomLenght(5, 50));
            }

            var index = 0;
            foreach (var manufacturer in manufacturersToBeAdded)
            {
                var newManufacturer = new Manufacturer
                {
                    Name = manufacturer,
                    Country = Random.GetRandomStringWithRandomLenght(2, 50)
                };

                this.Database.Manufacturers.Add(newManufacturer);

                index++;

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }
            Console.WriteLine("\nManufacturers Added!");
        }
    }
}
