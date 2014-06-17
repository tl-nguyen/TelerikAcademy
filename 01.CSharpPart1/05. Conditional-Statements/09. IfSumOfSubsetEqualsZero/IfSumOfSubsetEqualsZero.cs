using System;

class IfSumOfSubsetEqualsZero
{
    static void Main()
    {
        int[] numbers = { 3, -2, 1, 1, 8 };          // you can check with as many numbers as you want
        subsetNumbers(numbers);
    }

    static void subsetNumbers(int[] numbers)
    {
        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            int[] subset = new int[numbers.Length];
            int subsetCounter = i;
            sum = numbers[i];
            subset[subsetCounter] = numbers[i];
            for (int j = i+1; j < numbers.Length; j++, subsetCounter++)
            {
                sum += numbers[j];
                subset[j] = numbers[j];
                if (sum == 0)
                {
                    printSubsetWithSumOfZero(subset);
                }
            }    
        }
    }

    static void printSubsetWithSumOfZero(int[] subset)
    {
        foreach (var num in subset)
        {
            if (num == 0)
            {
                continue;
            }
            Console.Write("[{0}] ", num);
        }
        Console.WriteLine();
    }
}

