using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.FindIfAPathExistBetween2Cells
{
    class Program
    {
        static char[,] lab = {
                                {' ', ' ', ' ', '*', ' ', ' ', ' '},
                                {'*', '*', ' ', '*', ' ', '*', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                {' ', '*', '*', '*', '*', '*', '*'},
                                {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
                            };

        static void Main(string[] args)
        {

            try
            {
                FindExit(0, 0);
                Console.WriteLine("There's no path");
            }
            catch (Exception)
            {
                Console.WriteLine("There's a path between 2 cells");
            }
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
                throw new Exception("Fake exception to exit the recursion");
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
