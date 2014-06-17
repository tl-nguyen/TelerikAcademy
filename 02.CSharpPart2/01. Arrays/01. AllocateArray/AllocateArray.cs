using System;

class AllocateArray
{
    static void Main()
    {
        int[] nums = new int[20];

        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = i * 5;
            Console.WriteLine(nums[i]);
        }
    }
}

