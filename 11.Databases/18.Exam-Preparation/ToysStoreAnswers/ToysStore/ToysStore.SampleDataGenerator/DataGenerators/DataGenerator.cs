namespace ToysStore.SampleDataGenerator.DataGenerators
{
    using ToysStore.Data;

    using ToysStore.SampleDataGenerator.DataGenerators.Contracts;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private ToysStoreEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator random, ToysStoreEntities db, int count)
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

        protected ToysStoreEntities Database
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
