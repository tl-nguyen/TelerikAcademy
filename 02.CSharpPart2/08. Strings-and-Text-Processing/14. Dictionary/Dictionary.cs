using System;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>()
	    {
	        {".NET", "platform for applications from Microsoft"},
	        {"CLR", "managed execution environment for .NET"},
	        {"namespace", "hierarchical organization of classes"}
	    };

        string input = Console.ReadLine();

        if (dictionary.ContainsKey(input)) Console.WriteLine(dictionary[input]);
        else Console.WriteLine("no such word in dictionary");
    }
}

