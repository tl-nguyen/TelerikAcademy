using System;

class CompareTwoCharArrays
{
    static void Main()
    {
        char[] arr1 = new char[20];
        char[] arr2 = new char[20];

        for (int i = 0; i < arr1.Length; i++)
        {
            Console.Write("arr1[{0}] = ", i);
            arr1[i] = char.Parse(Console.ReadLine());
            Console.Write("arr2[{0}] = ", i);
            arr2[i] = char.Parse(Console.ReadLine());
            if (arr1[i] > arr2[i]) Console.WriteLine("arr1[{0}] > arr2[{0}]", i);
            else if (arr1[i] < arr2[i]) Console.WriteLine("arr1[{0}] < arr2[{0}]", i);
            else Console.WriteLine("arr1[{0}] = arr2[{0}]", i);
        }
    }
}

