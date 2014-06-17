using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Double radius;

        Console.Write("Enter the radius of the circle : ");
        radius = doubleValueInput();

        Console.WriteLine("the circle Perimeter = {0:0.00}", 2 * Math.PI * radius);
        Console.WriteLine("the circle Area = {0:0.00}", Math.PI * radius * radius);
    }

    static Double doubleValueInput()
    {
        Double number = 0;
        Boolean isNumber = false;

        do
        {
            isNumber = Double.TryParse(Console.ReadLine(), out number);
            if (!isNumber)
            {
                Console.Write("invalid input! Try again : ");
            }
        }
        while (!isNumber);

        return number;
    }
}

