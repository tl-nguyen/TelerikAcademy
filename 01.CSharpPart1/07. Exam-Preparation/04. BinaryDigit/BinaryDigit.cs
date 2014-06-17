using System;

class BinaryDigit
{
    static void Main()
    {
        int b = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int count;
        uint number;

        for (int i = 0; i < n; i++)
        {
            for(number = uint.Parse(Console.ReadLine()), count = 0; number != 0; number >>= 1)
            {
                if((number & 1) == b)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}

