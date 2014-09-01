using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HashTableImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashtable = new HashDictionary<string, string>();

            hashtable.Add("test", "blabalbla");
            hashtable.Add("test2", "blabalbla");
            hashtable.Add("test3", "blabalbla");
            hashtable.Add("test4", "blabalbla");
            hashtable.Add("test5", "blabalbla");

            foreach(var item in hashtable)
            {
                Console.WriteLine(item.Key + " => " + item.Value);
            }
        }
    }
}
