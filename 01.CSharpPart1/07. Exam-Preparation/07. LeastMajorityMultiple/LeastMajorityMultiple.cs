using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());
        int min = a;
        int result;

        if (b < min) min = b;
        if (c < min) min = c;
        if (d < min) min = d;
        if (e < min) min = e;

        result = min;

        while (true)
        {
            int count = 0;

            if (result % a == 0) count++;
            if (result % b == 0) count++;
            if (result % c == 0) count++;
            if (result % d == 0) count++;
            if (result % e == 0) count++;
            if (count >= 3) break;
            
            result++;
        }

        Console.WriteLine(result);
    } 
}

