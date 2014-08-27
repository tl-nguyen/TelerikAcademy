using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CustomArrayStack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private T[] elements = new T[0];
        private int index = -1;

        public int Count
        {
            get { return this.index + 1; }
        }

        public int Capacity
        {
            get { return this.elements.Length; }
        }

        public void Push(T value)
        {
            this.index++;
            if (this.Capacity < this.Count)
            {
                Resize();
            }
            this.elements[this.index] = value;
        }

        private void Resize()
        {
            int newSize = (this.Capacity != 0) ? (this.Capacity * 2) : 1;

            Array.Resize(ref this.elements, newSize);
        }

        public T Peek()
        {
            return this.elements[this.index];
        }

        public T Pop()
        {
            if (this.index == -1)
            {
                throw new Exception("stack is empty");
            }

            T returnedItem = this.elements[this.index];
            this.elements[this.index] = default(T);
            this.index--;

            return returnedItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.index; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
