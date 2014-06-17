using System;

class NullableDemo
{
    static void Main(string[] args)
    {
        int? nullableInteger = null;
        double? nullableDouble = null;

        Console.WriteLine("with null value : nullableInteger = " + nullableInteger);
        Console.WriteLine("with null value : nullableDouble = " + nullableDouble);

        nullableInteger = 10;
        nullableDouble = 20;

        Console.WriteLine("with not null value : nullableInteger = " + nullableInteger);
        Console.WriteLine("with not null value : nullableDouble = " + nullableDouble);
    }
}

