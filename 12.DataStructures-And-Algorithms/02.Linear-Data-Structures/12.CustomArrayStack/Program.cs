using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CustomArrayStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStack = new CustomStack<int>();

            myStack.Push(10);
            myStack.Push(14);
            myStack.Push(213);
            myStack.Push(12);

            Console.WriteLine("Peek: " + myStack.Peek());
            Console.WriteLine("Pop: " + myStack.Pop());

            foreach(var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
