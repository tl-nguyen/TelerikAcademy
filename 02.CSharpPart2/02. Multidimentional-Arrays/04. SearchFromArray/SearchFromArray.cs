using System;

class SearchFromArray
{
    static void Main()
    {
        Console.Write("array's size = ");
        int size = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());
        int[] nums = new int[size];

        for (int i = 0; i < nums.Length; i++)
		{
            Console.Write("nums[{0}] = ", i);
            nums[i] = int.Parse(Console.ReadLine());
		}

        Array.Sort(nums);

        Console.WriteLine(LargestNumber(nums, k));
    }

    private static int LargestNumber(int[] nums, int k)
    {
        int low = 0;
        int high = nums.Length - 1;
        int mid;

        while (low < high)
        {
            mid = (low + high) / 2;

            if (nums[mid] == k)
            {
                return nums[mid];
            }
            else if (nums[mid] > k)
            {
                high = mid - 1;
            }
            else
            {
                low = mid;
            }
        }

        return nums[low];
    }
}

