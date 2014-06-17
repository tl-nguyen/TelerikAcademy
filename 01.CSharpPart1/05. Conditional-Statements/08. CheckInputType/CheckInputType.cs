using System;

class CheckInputType
{
    static void Main()
    {
        Double number;
        Console.Write("Enter input data : ");
        String input = Console.ReadLine();
        Boolean isNumber = double.TryParse(input, out number);

        if(isNumber)
            Console.WriteLine(number + 1);
        else
            Console.WriteLine(input + "*");
    }
}

