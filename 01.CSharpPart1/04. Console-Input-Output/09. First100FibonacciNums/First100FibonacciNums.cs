using System;

class First100FibonacciNums
{
    static void Main()
    {
        decimal prevNum = 0;
        decimal curNum = 1;
        decimal sum = 0;

        Console.WriteLine(prevNum+"\n"+curNum);
        for (int i = 2; i < 100; i++)
        {
            sum = prevNum + curNum;
            Console.WriteLine(sum);
            
            prevNum = curNum;
            curNum = sum;
        }
    }
}

