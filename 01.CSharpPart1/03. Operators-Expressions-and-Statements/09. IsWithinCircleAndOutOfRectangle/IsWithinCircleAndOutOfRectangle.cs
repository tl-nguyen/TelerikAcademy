using System;

class IsWithinCircleAndOutOfRectangle
{
    static void Main()
    {
        int x = 1;
        int y = 5;
        int centerPointXCordinate = 1;
        int centerPointYCordinate = 1;
        int circumferencePoint = 5;
        int rectangleTop = 1;
        int rectangleLeft = -1;
        int rectangleWidth = 6;
        int rectangleHeight = 2;

        Console.WriteLine(  "The given point ({0},{1}) is within the circle K(({2},{3},{4}) and out of the Rectangle ({5},{6},{7},{8}) : {9} "
                            , x, y
                            , centerPointXCordinate, centerPointYCordinate, circumferencePoint
                            , rectangleTop, rectangleLeft, rectangleWidth, rectangleHeight
                            , isWithinTheCircle(centerPointXCordinate, centerPointYCordinate, circumferencePoint, x, y)
                                && isOutOfRectangle(rectangleTop, rectangleLeft, rectangleWidth, rectangleHeight, x, y));
        ;
    }

    static Boolean isWithinTheCircle(   int centerPointXCordinate
                                        , int centerPointYCordinate
                                        , int circumferencePoint
                                        , int x
                                        , int y)
    {
        int radius = Math.Abs(circumferencePoint - centerPointXCordinate);
        int xToCenterLength = Math.Abs(x - centerPointXCordinate);
        int yToCenterLength = Math.Abs(y - centerPointYCordinate);

        return (xToCenterLength * xToCenterLength + yToCenterLength * yToCenterLength) < (radius * radius);
    }

    static Boolean isOutOfRectangle(int top, int left, int width, int height, int x, int y)
    {
        return (x > top && x < top - height && y < left && y > left + width);
    }
}

