using System;

class MinMaxAverageSumProduct
{
    static void Main()
    {
        int[] arr = { 9, -1, -3, 1 };

        Console.WriteLine(Min(arr));
        Console.WriteLine(Max(arr));
        Console.WriteLine(Average(arr));
        Console.WriteLine(Sum(arr));
        Console.WriteLine(Product(arr));
    }

    static T Min<T>(T[] arr) where T : IComparable<T>
    {
        int best = 0;

        for (int i = 1; i < arr.Length; i++)
            if (arr[i].CompareTo(arr[best]) < 0) best = i;

        return arr[best];
    }

    static T Max<T>(T[] arr) where T : IComparable<T>
    {
        int best = 0;

        for (int i = 1; i < arr.Length; i++)
            if (arr[i].CompareTo(arr[best]) > 0) best = i;

        return arr[best];
    }

    static double Average<T>(T[] arr)
    {
        return Convert.ToDouble(Sum(arr)) / arr.Length;
    }

    static T Sum<T>(T[] arr)
    {
        dynamic accum = 0;

        for (int i = 0; i < arr.Length; i++) accum += arr[i];

        return accum;
    }

    static T Product<T>(T[] arr)
    {
        dynamic accum = 1;

        for (int i = 0; i < arr.Length; i++) accum *= arr[i];

        return accum;
    }
}

