using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var myQueue = new LinkedQueue<int>();

            myQueue.Enqueue(20);
            myQueue.Enqueue(3);
            myQueue.Enqueue(210);
            myQueue.Enqueue(202);
            myQueue.Enqueue(2011);

            Console.WriteLine("Peek " + myQueue.Peek());
            Console.WriteLine("Dequeue " + myQueue.Dequeue());

            foreach(var item in myQueue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
