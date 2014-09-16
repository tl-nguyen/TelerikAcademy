using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frames
{
    class FramesSolution
    {
        static Element[] elements;

        static SortedSet<string> result = new SortedSet<string>();

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            elements = new Element[count];

            for (var i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                elements[i] = new Element(int.Parse(line[0]), int.Parse(line[1]));
            }

            GeneratePermutations(elements, 0);

            Console.WriteLine(result.Count);

            Print(result);
        }

        private static void Print(SortedSet<string> result)
        {
            var resultPrint = new StringBuilder();

            foreach (var line in result)
            {
                resultPrint.AppendLine(line);
            }

            Console.WriteLine(resultPrint.ToString());
        }


        
        static void GeneratePermutations(Element[] arr, int k)
        {
            if (k >= arr.Length)
            {
                var stringJoin = new StringBuilder();

                for (var i = 0; i < arr.Length; i++)
                {
                    if (i == arr.Length - 1)
                    {
                        stringJoin.Append(arr[i]);
                        continue;
                    }

                    stringJoin.Append(arr[i] + " | ");
                }

                stringJoin.AppendLine();

                result.Add(stringJoin.ToString().Trim());
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                Flip(ref arr[k]);
                GeneratePermutations(arr, k + 1);
                Flip(ref arr[k]);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    
                    GeneratePermutations(arr, k + 1);
                    Flip(ref arr[k]);
                    GeneratePermutations(arr, k + 1);
                    Flip(ref arr[k]);

                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static void Flip(ref Element el)
        {
            var temp = el.First;

            el.First = el.Second;
            el.Second = temp;
        }
    }

    public class Element
    {
        public Element(int first, int second)
        {
            this.First = first;
            this.Second = second;
        }

        public int First { get; set; }
        public int Second { get; set; }

        public override string ToString()
        {
            return String.Format("({0}, {1})", First, Second);
        }
    }
}
