using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _04.HashTableImplementation;

namespace _05.HashedSet
{
    class HashedSet<T>
    {
        private HashDictionary<T, bool> values = new HashDictionary<T, bool>();

        public int Count
        {
            get { return this.values.Count; }
        }

        public void Add(T value)
        {
            if (!this.Contains(value))
            {
                this.values.Add(value, true);
            }
        }

        public bool Contains(T value)
        {
            return this.values.ContainsKey(value);
        }

        public bool Remove(T value)
        {
            return this.values.Remove(value);
        }

        public void Union(IEnumerable<T> elements)
        {
            foreach (var element in elements)
            {
                this.Add(element);
            }
        }

        public void Intersect(IEnumerable<T> elements)
        {
            var other = new HashSet<T>();
            foreach (var element in elements)
            {
                other.Add(element);
            }

            foreach (var element in this.values.Select(kvp => kvp.Key).ToArray())
            {
                if (!other.Contains(element))
                {
                    this.Remove(element);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.values.Select(p => p.Key).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
