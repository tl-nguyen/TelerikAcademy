using System;

class BracketsCheck
{
    private static bool GoodBrackets(string expression)
    {
        int openBracket = 0;
        int closeBracket = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(') openBracket++;
            else if (expression[i] == ')') closeBracket++;

            if (openBracket < closeBracket) return false;
        }
        
        return openBracket == closeBracket; 
    }

    static void Main()
    {
        //string expression = "((a+b)/5-d)"; 
        //string expression = ")(a+b))";
        string expression = ")((a+b))(";

        Console.WriteLine(GoodBrackets(expression));
    }
}

