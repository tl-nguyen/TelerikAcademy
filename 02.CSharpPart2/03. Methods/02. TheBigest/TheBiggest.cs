using System;

class TheBiggest
{
    static void Main(string[] args)
    {
        Console.Write("Enter num1 = ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter num2 = ");
        int num2 = int.Parse(Console.ReadLine());
        Console.Write("Enter num3 = ");
        int num3 = int.Parse(Console.ReadLine());

        int max = GetMax(GetMax(num1, num2), num3);

        Console.WriteLine("Max = {0}", max);
    }

    static public int GetMax(int num1, int num2)
    {
        if (num1 > num2) return num1;
        return num2;
    }
}

