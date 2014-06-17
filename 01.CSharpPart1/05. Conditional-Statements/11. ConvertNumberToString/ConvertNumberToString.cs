using System;

class ConvertNumberToString
{
    static void Main()
    {
        int[] numbers = { 0, 4, 22, 111, 234, 231, 534, 676, 999 };

        foreach (int number in numbers)
        {
            Console.WriteLine(number + " -> " + ConvertToString(number));
        }
    }

    static String ConvertToString(int number)
    {
        String[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        String[] tens = { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        String result = "";

        if (number > 99)
        {
            result += ones[number / 100] + " hundred";
            number %= 100;

            if (number != 0) result += " and "; 
            else return result;
        }

        if (number > 19)
        {
            result += tens[number / 10 - 2];
            number %= 10;

            if (number != 0) result += "-";
            else return result;
        }

        result += ones[number]; 

        return result;
    }
}

