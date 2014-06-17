using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        int firstNum = 30;
        int secondNum = 100;

        while (firstNum != 0)
        {
            int temp = firstNum;
            firstNum = secondNum % firstNum;
            secondNum = temp;
        }
    }
}

