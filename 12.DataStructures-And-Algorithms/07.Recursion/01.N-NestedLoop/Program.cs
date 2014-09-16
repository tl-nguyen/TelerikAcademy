namespace _01.N_NestedLoop
{
    class Program
    {
        static void Main()
        {
            int n = 2;
            GenerateLoop(new int[n], 0);
        }

        public static void GenerateLoop(int[] arr, int currentIndex)
        {
            if (currentIndex == arr.Length)
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    System.Console.Write(arr[i]);
                }

                System.Console.WriteLine();

                return;
            }

            for (var i = 0; i < arr.Length; i++)
            {
                arr[currentIndex] = i + 1;
                GenerateLoop(arr, currentIndex + 1);
            }
        }
    }
}
