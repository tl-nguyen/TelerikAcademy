using System;

class SquareRootCal
{
    static void Main()
    {
        try
        {
            Console.Write("Enter ur number: ");
            int num = int.Parse(Console.ReadLine());

            if (num < 0) throw new Exception();

            Console.WriteLine("Square root of {0} is {1}", num, Math.Sqrt(num));
        }
        catch(Exception)
        {
            Console.Error.WriteLine("Invalid number");
        }
        finally
        {
            Console.Error.WriteLine("Good bye");
        }
    }
}

