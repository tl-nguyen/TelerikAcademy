using System;

class HelloMethod
{
    static void Main()
    {
        SayHello();
    }

    static public void SayHello()
    {
        Console.WriteLine("What's ur name ?");
        String name = Console.ReadLine();

        Console.WriteLine("Hello {0}", name);
    }
}

