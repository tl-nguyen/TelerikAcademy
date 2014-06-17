using System;

class StringAndObjectDeclare
{
    static void Main()
    {
        String hello = "Hello";
        String world = "World";
        Object concat = hello + " " + world;
        String helloWorld = (String) concat;

        Console.WriteLine(helloWorld);
    }
}

