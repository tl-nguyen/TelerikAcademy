using System;

class EnterNumberInRange
{
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            ReadNumber(1, 100);
        } 
    }

    private static void ReadNumber(int start, int end)
    {
        try
        {
            int num = int.Parse(Console.ReadLine());
            if (num < start || num > end) throw new IndexOutOfRangeException();

            Console.WriteLine("number {0} is valid", num);
        }
        catch (IndexOutOfRangeException)
        {
            Console.Error.WriteLine("Not in range of {0}-{1}", start, end);
        }
        catch (Exception)
        {
            Console.Error.WriteLine("Invalid Number");
        }

    }


}

