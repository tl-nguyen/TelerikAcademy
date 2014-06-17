using System;

class CompareTwoArrays
{
    static void Main()
    {
        int[] arr1 = new int[20];
        int[] arr2 = new int[20];

        for (int i = 0; i < arr1.Length; i++)
        {
            Console.Write("arr1[{0}] = ", i);
            arr1[i] = int.Parse(Console.ReadLine());
            Console.Write("arr2[{0}] = ", i);
            arr2[i] = int.Parse(Console.ReadLine());
            if (arr1[i] > arr2[i]) Console.WriteLine("arr1[{0}] > arr2[{0}]", i);
            else if (arr1[i] < arr2[i]) Console.WriteLine("arr1[{0}] < arr2[{0}]", i);
            else Console.WriteLine("arr1[{0}] = arr2[{0}]", i);
        }
    }
}

