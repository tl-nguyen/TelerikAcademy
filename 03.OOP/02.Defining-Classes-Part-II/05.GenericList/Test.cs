using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Test
{
    public static void Main()
    {
        var myList = new GenericList<double>();

        // test Add and the auto growing function when the initial capacity is 10
        for (int i = 0; i < 50; i++)
        {
            myList.Add(i);
        }
        
        //testing toString()
        Console.WriteLine("Initial elements : {0}",myList.ToString());

        //testing Remove()
        myList.Remove(0);
        Console.WriteLine("After RemoveElement(0): {0}", myList.ToString());

        //testing Access()
        Console.WriteLine("The element with index 10 = {0}", myList.Access(10)); 

        //testing Insert()
        myList.Insert(0, 4);
        Console.WriteLine("After Insert(0,4): {0}", myList.ToString());

        //test Max()
        Console.WriteLine("Max Element = {0}", myList.Max());

        //test Min()
        Console.WriteLine("Min Element = {0}", myList.Min());

        //test Clear()
        myList.Clear();
        Console.WriteLine("After Clear(): {0}", myList.ToString());

    }
}

