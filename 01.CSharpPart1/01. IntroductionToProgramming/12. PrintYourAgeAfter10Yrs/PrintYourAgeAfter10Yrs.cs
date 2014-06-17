using System;

class PrintYourAgeAfter10Yrs
{
    static void Main(string[] args)
    {
        int yourAge = 0;
        Boolean isNumber = false;

        while (!isNumber)
        {
            Console.Write("Enter your age: ");
            isNumber = int.TryParse(Console.ReadLine(),out yourAge);
            if(!isNumber) 
                Console.WriteLine("!!! You didn't enter a number");
        }
        
        Console.WriteLine("After 10 years, your age will be: " + (yourAge + 10));
    }
}

