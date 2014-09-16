namespace Company.SampleDataGenerator.DataGenerators.Contracts
{
    internal interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLenght(int min, int max);
    }
}
