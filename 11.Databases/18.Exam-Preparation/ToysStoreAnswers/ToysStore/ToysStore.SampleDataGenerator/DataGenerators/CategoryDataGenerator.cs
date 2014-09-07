namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using System;

    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.DataGenerators.Contracts;

    internal class CategoryDataGenerator : DataGenerator, IDataGenerator
    {
        public CategoryDataGenerator(IRandomDataGenerator random, ToysStoreEntities db, int count)
            : base(random, db, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Categories");
            for (int i = 0; i < this.Count; i++)
            {
                var category = new Category
                {
                    Name = Random.GetRandomStringWithRandomLenght(5, 50),
                };

                this.Database.Categories.Add(category);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }
            Console.WriteLine("\nCategories Added!");
        }
    }
}
