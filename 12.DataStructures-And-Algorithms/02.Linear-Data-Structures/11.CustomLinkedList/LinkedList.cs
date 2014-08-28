using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CustomLinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList(T val)
        {
            this.AddFirst(val);
        }

        public ListItem<T> FirstElement { get; private set; }
        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            var item = new ListItem<T>(value);

            this.Count++;

            if(this.FirstElement == null)
            {
                this.FirstElement = item;
            }
            else
            {
                item.NextItem = this.FirstElement;
                this.FirstElement = item;
            }
        }

        public ListItem<T> RemoveFirst()
        {
            var returnedItem = this.FirstElement;

            this.Count--;

            if(this.FirstElement == null)
            {
                return null;
            }

            if(this.FirstElement.NextItem == null)
            {
                this.FirstElement = null;
            }
            else
            {
                this.FirstElement = this.FirstElement.NextItem;
            }

            return returnedItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = this.FirstElement; current != null; current = current.NextItem)
            {
                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
