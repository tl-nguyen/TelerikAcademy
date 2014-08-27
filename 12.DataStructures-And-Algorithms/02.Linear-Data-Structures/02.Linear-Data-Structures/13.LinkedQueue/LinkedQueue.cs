using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedQueue
{
    class LinkedQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> elements = new LinkedList<T>();
        public int Count { get; private set; }

        public void Enqueue(T value)
        {
            Count++;
            this.elements.AddLast(value);
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new Exception("queue is empty");
            }

            Count--;
            var removedElement = this.elements.First.Value;
            this.elements.RemoveFirst();

            return removedElement;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new Exception("queue is empty");
            }

            return this.elements.First.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
