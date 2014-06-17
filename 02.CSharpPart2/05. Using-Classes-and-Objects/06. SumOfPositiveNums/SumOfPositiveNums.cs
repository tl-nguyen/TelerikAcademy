using System;

class SumOfPositiveNums
{
    static void Main()
    {
        string stringOfNums = "43 68 9 23 318";
        string[] nums = stringOfNums.Split(' ');
        int sum = 0;

        foreach (var num in nums) sum += int.Parse(num);

        Console.WriteLine(sum);
    }
}

