using System;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a > 0 &&
                b > 0 &&
                c > 0) 
            {
                double s = (a + b + c) / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                return area;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }
        }

        static string NumberToString(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "Invalid number";
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("elements can't be null");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException("elements must be more than 0");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (maxElement < elements[i])
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        static void PrintAsNumber(object number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("format is invalid");
            }
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        static bool IsVertical(double x1, double x2)
        {
            return x1 == x2;
        }

        static bool IsHorizontal(double y1, double y2)
        {
            return y1 == y2;
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToString(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontal(-1, 2.5));
            Console.WriteLine("Vertical? " + IsVertical(3, 3));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
