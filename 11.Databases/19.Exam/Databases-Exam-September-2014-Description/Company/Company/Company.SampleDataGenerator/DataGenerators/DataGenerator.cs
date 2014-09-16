namespace Company.SampleDataGenerator.DataGenerators
{
    using Company.Data;

    using Company.SampleDataGenerator.DataGenerators.Contracts;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator random, CompanyEntities db, int count)
        {
            this.random = random;
            this.db = db;
            this.count = count;
        }

        protected IRandomDataGenerator Random
        {
            get
            {
                return this.random;
            }
        }

        protected CompanyEntities Database
        {
            get
            {
                return this.db;
            }
        }

        protected int Count
        {
            get
            {
                return this.count;
            }
        }

        public abstract void Generate();
    }
}
