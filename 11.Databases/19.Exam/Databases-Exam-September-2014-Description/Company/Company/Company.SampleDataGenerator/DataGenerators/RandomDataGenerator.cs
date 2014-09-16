namespace Company.SampleDataGenerator.DataGenerators
{
    using System;

    using Company.SampleDataGenerator.DataGenerators.Contracts;

    internal class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static IRandomDataGenerator randomDataGenerator;
        private Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance
        {
            get
            {
                if (randomDataGenerator == null)
                {
                    randomDataGenerator = new RandomDataGenerator();
                }

                return randomDataGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var randomWord = new char[length];

            for (var i = 0; i < length; i++)
            {
                randomWord[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(randomWord);
        }

        public string GetRandomStringWithRandomLenght(int min, int max)
        {
            return this.GetRandomString(this.GetRandomNumber(min, max));
        }
    }
}
