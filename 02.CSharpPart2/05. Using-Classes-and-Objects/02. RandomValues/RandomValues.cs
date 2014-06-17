using System;

class RandomValues
{
    static void Main()
    {
        Random randGenerator = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(randGenerator.Next(100, 200));    
        }
    }
}

