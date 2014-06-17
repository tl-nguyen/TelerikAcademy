using System;

class IsoscelesTriangleWithCSymbol
{
    static void Main()
    {
        char copyRightSymbol = (char)0x24B8;
        int maxHeight = 3;                      // you can change this variable for bigger triangle
        int maxSpaces = maxHeight-1;            // max spaces on the left side of the printed symbols
        
        for(int counter = 1; counter <= maxHeight; counter++, maxSpaces--)
        {
            for(int spaceCount = 0; spaceCount < maxSpaces; spaceCount++)
            {
                Console.Write(" ");
            }
            for (int symbolCount = 1; symbolCount <= (counter*2-1); symbolCount++ )
            {
                Console.Write(copyRightSymbol);
            }
            Console.WriteLine();
        }
    }
}

