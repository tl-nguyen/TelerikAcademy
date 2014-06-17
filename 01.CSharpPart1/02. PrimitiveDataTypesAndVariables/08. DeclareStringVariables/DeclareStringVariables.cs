using System;

class DeclareStringVariables
{
    static void Main(string[] args)
    {
        String withoutQuotedString = "The use of quotations causes difficulties";
        String withQuotedString = "The \"use\" of quotations causes difficulties";

        Console.WriteLine("String without quotes : {0} \nString with quotes : {1}", withoutQuotedString, withQuotedString);
    }
}

