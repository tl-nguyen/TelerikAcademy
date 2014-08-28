using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> myList = new LinkedList<int>(40);
            myList.AddFirst(30);
            myList.AddFirst(14);

            foreach(var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
