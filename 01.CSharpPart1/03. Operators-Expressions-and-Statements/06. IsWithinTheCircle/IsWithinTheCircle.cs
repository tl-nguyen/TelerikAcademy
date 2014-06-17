using System;

class IsWithinTheCircle
{
    static void Main()
    {
        int x = 1;
        int y = 5;
        int centerPoint = 0;
        int circumferencePoint = 5;

        isWithinTheCircle(centerPoint, circumferencePoint, x, y);
    }

    static void isWithinTheCircle(int centerPoint, int circumferencePoint,int x,int y)
    {
        int radius = Math.Abs(circumferencePoint - centerPoint);
        int xToCenterLength = Math.Abs(x - centerPoint);
        int yToCenterLength = Math.Abs(y - centerPoint);

        Console.WriteLine("The point ({0},{1}) is within the circle({2},{3}) : {4}" , x
                                                                                    , y
                                                                                    , centerPoint
                                                                                    , circumferencePoint
                                                                                    , ((xToCenterLength*xToCenterLength + yToCenterLength*yToCenterLength) < radius*radius));
    }
}

