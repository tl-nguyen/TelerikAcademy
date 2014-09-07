namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.DataGenerators.Contracts;

    class ToyDataGenerator : DataGenerator, IDataGenerator
    {
        public ToyDataGenerator(IRandomDataGenerator random, ToysStoreEntities db, int count)
            : base(random, db, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Toys");

            var ageRangeIds = this.Database.AgeRanges.Select(a => a.Id).ToList();
            var manufacturerIds = this.Database.Manufacturers.Select(m => m.Id).ToList();
            var categoryIds = this.Database.Categories.Select(c => c.Id).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var toy = new Toy
                {
                    Name = this.Random.GetRandomStringWithRandomLenght(5, 50),
                    Type = this.Random.GetRandomStringWithRandomLenght(5, 20),
                    Price = this.Random.GetRandomNumber(10, 500),
                    Color = this.Random.GetRandomNumber(1, 5) == 5 ? null : this.Random.GetRandomStringWithRandomLenght(3,20),
                    AgeRangeId = ageRangeIds[this.Random.GetRandomNumber(0, ageRangeIds.Count - 1)],
                    ManufacturerId = manufacturerIds[this.Random.GetRandomNumber(0, manufacturerIds.Count - 1)]
                };

                if (categoryIds.Count > 0)
                {
                    var uniqueCategoryIds = new HashSet<int>();

                    var categoriesCount = this.Random.GetRandomNumber(1, Math.Min(1, categoryIds.Count));

                    while (uniqueCategoryIds.Count != categoriesCount)
                    {
                        uniqueCategoryIds.Add(categoryIds[this.Random.GetRandomNumber(0, categoryIds.Count - 1)]);
                    }

                    foreach (var uniqueCategoryId in uniqueCategoryIds)
                    {
                        toy.Categories.Add(this.Database.Categories.Find(uniqueCategoryId));
                    }
                }

                this.Database.Toys.Add(toy);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nToys Added!");
        }
    }
}
