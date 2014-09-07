namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using System;

    using ToysStore.Data;
    using ToysStore.SampleDataGenerator.DataGenerators.Contracts;

    class AgeRangeDataGenerator : DataGenerator, IDataGenerator
    {
        public AgeRangeDataGenerator(IRandomDataGenerator random, ToysStoreEntities db, int count)
            : base(random, db, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding AgeRanges");

            int count = 0;

            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i + 1; j <= i + 5; j++)
                {
                    var ageRange = new AgeRanx
                    {
                        MinAge = i,
                        MaxAge = j
                    };

                    this.Database.AgeRanges.Add(ageRange);

                    count++;

                    if (count % 100 == 0)
                    {
                        Console.Write(".");
                        this.Database.SaveChanges();
                    }

                    if (count == this.Count)
                    {
                        return;
                    }
                }
            }
            Console.WriteLine("\nAgeRanges Added!");
        }
    }
}
