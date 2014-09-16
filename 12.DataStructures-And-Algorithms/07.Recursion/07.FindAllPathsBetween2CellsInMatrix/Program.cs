using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindAllPathsBetween2CellsInMatrix
{
    class Program
    {
        static char[,] lab = {
                                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                {'*', '*', ' ', '*', ' ', '*', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                {' ', '*', '*', '*', '*', '*', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
                            };
        static int result = 0;

        static void Main(string[] args)
        {
            FindExit(0, 0);
            Console.WriteLine(result);
        }

        static void FindExit(int row, int col)
        {
            if (row < 0 || row >= lab.GetLength(0)
                    || col < 0 || col >= lab.GetLength(1))
            {
                return;
            }

            if (lab[row, col] == 'e')
            {
                result++;
                return;
            }
            
            if (lab[row, col] != ' ')
            {
                return;
            }

            lab[row, col] = 'x';

            FindExit(row, col + 1);
            FindExit(row + 1, col);
            FindExit(row, col - 1);
            FindExit(row - 1, col);

            lab[row, col] = ' ';
        }
    }
}
