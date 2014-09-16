using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] startPos = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            Cell<int> startCell = new Cell<int>(startPos[0], startPos[1], startPos[2], 0);

            int[] labSize = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var l = labSize[0];
            var r = labSize[1];
            var c = labSize[2];


            var labyrinth = new char[l, r, c];

            var used = new HashSet<Cell<int>>();

            for (var level = 0; level < l; level++)
            {
                for (var row = 0; row < r; row++)
                {
                    string inputRow = Console.ReadLine();

                    for (var col = 0; col < c; col++)
                    {
                        labyrinth[level, row, col] = inputRow[col];
                        if (inputRow[col] == '#')
                        {
                            used.Add(new Cell<int>(level, row, col, -1));
                        }
                    }
                }
            }

            //bfs implementation

            var queue = new Queue<Cell<int>>();
            queue.Enqueue(startCell);
            used.Add(startCell);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                // Left -> col--
                if (cell.Column > 0)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row, cell.Column - 1, cell.QueueLevel + 1);
                    if (!used.Contains(newCell))
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Right -> col++
                if (cell.Column < c - 1)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row, cell.Column + 1, cell.QueueLevel + 1);
                    if (!used.Contains(newCell))
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }
                // Up -> row--
                if (cell.Row > 0)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row - 1, cell.Column, cell.QueueLevel + 1);
                    if (!used.Contains(newCell))
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Down -> row++
                if (cell.Row < r - 1)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row + 1, cell.Column, cell.QueueLevel + 1);
                    if (!used.Contains(newCell))
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // if (U) -> level++
                //          -> out of labyrinth
                if (labyrinth[cell.Level, cell.Row, cell.Column] == 'U')
                {
                    if (cell.Level == l - 1)
                    {
                        Console.WriteLine(cell.QueueLevel + 1);
                        Environment.Exit(0);
                    }
                    else
                    {
                        var newCell = new Cell<int>(cell.Level + 1, cell.Row, cell.Column, cell.QueueLevel + 1);
                        if (!used.Contains(newCell))
                        {
                            queue.Enqueue(newCell);
                            used.Add(newCell);
                        }
                    }
                }

                // if (D) -> level--
                //          -> out of labyrinth
                if (labyrinth[cell.Level, cell.Row, cell.Column] == 'D')
                {
                    if (cell.Level == 0)
                    {
                        Console.WriteLine(cell.QueueLevel + 1);
                        Environment.Exit(0);
                    }
                    else
                    {
                        var newCell = new Cell<int>(cell.Level - 1, cell.Row, cell.Column, cell.QueueLevel + 1);
                        if (!used.Contains(newCell))
                        {
                            queue.Enqueue(newCell);
                            used.Add(newCell);
                        }
                    }
                }
            }
        }
    }

    class Cell<T>
    {
        public Cell(T level, T row, T column, int queueLevel)
        {
            this.Level = level;
            this.Row = row;
            this.Column = column;
            this.QueueLevel = queueLevel;
        }

        public T Level { get; set; }
        public T Row { get; set; }
        public T Column { get; set; }
        public int QueueLevel { get; set; }

        public override bool Equals(object obj)
        {
            var otherCell = obj as Cell<T>;

            if (otherCell == null)
            {
                return false;
            }

            return this.Level.Equals(otherCell.Level)
                && this.Row.Equals(otherCell.Row)
                && this.Column.Equals(otherCell.Column);
        }

        public override int GetHashCode()
        {
            return this.Level.GetHashCode() ^
                this.Row.GetHashCode() ^
                this.Column.GetHashCode();
        }
    }
}
