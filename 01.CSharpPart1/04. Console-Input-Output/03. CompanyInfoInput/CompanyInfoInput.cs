using System;

class CompanyInfoInput
{
    static void Main()
    {
        Console.Write("Enter the Company name : ");
        String companyName = Console.ReadLine();
        Console.Write("Enter the Company address: ");
        String companyAddress = Console.ReadLine();
        Console.Write("Enter the Company phone number: ");
        long companyPhoneNum = integerValueInput();
        Console.Write("Enter the Company fax number: ");
        long companyFaxNum = integerValueInput();
        Console.Write("Enter the Manager first name: ");
        String managerFirstName = Console.ReadLine();
        Console.Write("Enter the Manager last name: ");
        String managerLastName = Console.ReadLine();
        Console.Write("Enter the Manager age : ");
        short managerAge = shortValueInput();
        Console.Write("Enter the Manager phone number : ");
        long managerPhoneNum = integerValueInput();

        Console.WriteLine("the Company name : {0}", companyName);
        Console.WriteLine("the Company address: {0}", companyAddress);
        Console.WriteLine("the Company phone number: {0}", companyPhoneNum);
        Console.WriteLine("the Company fax number: {0}", companyFaxNum);
        Console.WriteLine("the Manager first name: {0}", managerFirstName);
        Console.WriteLine("the Manager last name: {0}", managerLastName);
        Console.WriteLine("the Manager age : {0}", managerAge);
        Console.WriteLine("the Manager phone number : {0}", managerPhoneNum);
    }
    
    static long integerValueInput()
    {
        long number = 0;
        Boolean isNumber = false;

        do
        {
            isNumber = long.TryParse(Console.ReadLine(), out number);
            if (!isNumber)
            {
                Console.Write("invalid input! Try again : ");
            }
        }
        while (!isNumber);

        return number;
    }

    static short shortValueInput()
    {
        short number = 0;
        Boolean isNumber = false;

        do
        {
            isNumber = short.TryParse(Console.ReadLine(), out number);
            if (!isNumber)
            {
                Console.Write("invalid input! Try again : ");
            }
        }
        while (!isNumber);

        return number;
    }
}

