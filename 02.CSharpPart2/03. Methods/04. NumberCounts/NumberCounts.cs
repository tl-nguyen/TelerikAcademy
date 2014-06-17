using System;

class NumberCounts
{
    static void Main()
    {
        int[] arr = { 0, 32, 12, 22, 22, 1, 22, 13, 32, 12, 1, 12 };
        int num = 12;

        Console.WriteLine("there're {0} times, number {1} appears in the array", NumberCountsInArray(arr, num), num);
    }

    static public int NumberCountsInArray(int[] arr, int num)
    {
        int count = 0;
        foreach (var item in arr)
        {
            if (item == num) count++;
        }
        return count;
    }
}

