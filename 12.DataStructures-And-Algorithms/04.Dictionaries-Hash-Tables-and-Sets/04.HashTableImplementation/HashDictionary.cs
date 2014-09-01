using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HashTableImplementation
{
    public class HashDictionary<K, V>: IEnumerable<KeyValuePair<K, V>>
    {
        private LinkedList<KeyValuePair<K, V>>[] values;

        public HashDictionary()
        {
            this.values = new LinkedList<KeyValuePair<K, V>>[4];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }

        public void Add(K key, V value)
        {
            var hash = key.GetHashCode();
            hash %= this.Capacity;
            hash = Math.Abs(hash);
            
            if (this.values[hash] == null)
            {
                this.values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var alreadyHasKey = this.values[hash].Any(p => p.Key.Equals(key));

            if (alreadyHasKey)
            {
                throw new ArgumentException("Key already exists");
            }

            var newPair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(newPair);
            this.Count++;

            if (this.Count >= 0.75 * this.Capacity)
            {
                this.ResizeCapacity();
            }
        }

        public bool ContainsKey(K key)
        {

            return true;
        }

        private void ResizeCapacity()
        {
            var cachedValues = this.values;

            this.values = new LinkedList<KeyValuePair<K, V>>[2 * this.Capacity];

            this.Count = 0;

            foreach (var valueCollection in cachedValues)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }

        public bool Remove(K key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            var index = this.GetIndex(key);

            try
            {
                var result = this.GetKey(key, index);
                this.values[index].Remove(result);

                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        private KeyValuePair<K, V> GetKey(K key, int index)
        {
            return this.values[index].First(p => p.Key.Equals(key));
        }

        private int GetIndex(K key)
        {
            var hash = Math.Abs(key.GetHashCode());
            var index = hash % this.Capacity;

            return index;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var valueCollection in this.values)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        yield return value;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
