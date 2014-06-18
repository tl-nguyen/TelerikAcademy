using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
	public class Mine
	{
		public class Player
		{
			string name;
			int score;

			public string Name
			{
				get { return name; }
				set { name = value; }
			}

			public int Score
			{
				get { return score; }
				set { score = value; }
			}

			public Player() { }

			public Player(string name, int score)
			{
				this.name = name;
				this.score = score;
			}
		}

		static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] field = MakePlayField();
			char[,] mines = TrapMines();
			int cellsOpened = 0;
			bool isGameOver = false;
			List<Score> champions = new List<Score>(6);
			int row = 0;
			int col = 0;
			bool isFirstMove = true;
			const int max = 35;
			bool allCellsOpened = false;

			do
			{
				if (isFirstMove)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
					" command 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					PrintField(field);
					isFirstMove = false;
				}
				Console.Write("Daj row i col : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out col) &&
						row <= field.GetLength(0) && col <= field.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						PrintScores(champions);
						break;
					case "restart":
						field = MakePlayField();
						mines = TrapMines();
						PrintField(field);
						isGameOver = false;
						isFirstMove = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (mines[row, col] != '*')
						{
							if (mines[row, col] == '-')
							{
								MakeAMove(field, mines, row, col);
								cellsOpened++;
							}
							if (max == cellsOpened)
							{
								allCellsOpened = true;
							}
							else
							{
								PrintField(field);
							}
						}
						else
						{
							isGameOver = true;
						}
						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna command\n");
						break;
				}
				if (isGameOver)
				{
					PrintField(mines);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si nickName: ", cellsOpened);
					string nickName = Console.ReadLine();
					Score t = new Score(nickName, cellsOpened);
					if (champions.Count < 5)
					{
						champions.Add(t);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].Score < t.Score)
							{
								champions.Insert(i, t);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
					champions.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
					champions.Sort((Score r1, Score r2) => r2.Score.CompareTo(r1.Score));
					PrintScores(champions);

					field = MakePlayField();
					mines = TrapMines();
					cellsOpened = 0;
					isGameOver = false;
					isFirstMove = true;
				}
				if (allCellsOpened)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					PrintField(mines);
					Console.WriteLine("Daj si imeto, batka: ");
					string imeee = Console.ReadLine();
					Score scores = new Score(imeee, cellsOpened);
					champions.Add(scores);
					PrintScores(champions);
					field = MakePlayField();
					mines = TrapMines();
					cellsOpened = 0;
					allCellsOpened = false;
					isFirstMove = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void PrintScores(List<Score> scores)
		{
			Console.WriteLine("\nTo4KI:");
			if (scores.Count > 0)
			{
				for (int i = 0; i < scores.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, scores[i].Name, scores[i].Score);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void MakeAMove(char[,] POLE,
			char[,] BOMBI, int row, int col)
		{
			char minesCount = NeighbourMinesCount(BOMBI, row, col);
			BOMBI[row, col] = minesCount;
			POLE[row, col] = minesCount;
		}

		private static void PrintField(char[,] board)
		{
			int RRR = board.GetLength(0);
			int KKK = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < RRR; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < KKK; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] MakePlayField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] TrapBombs()
		{
			int rows = 5;
			int cols = 10;
			char[,] playFiled = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					playFiled[i, j] = '-';
				}
			}

			List<int> r3 = new List<int>();
			while (r3.Count < 15)
			{
				Random random = new Random();
				int randomNum = random.Next(50);
				if (!r3.Contains(randomNum))
				{
					r3.Add(randomNum);
				}
			}

			foreach (int i2 in r3)
			{
				int col = (i2 / cols);
				int row = (i2 % cols);
				if (row == 0 && i2 != 0)
				{
					col--;
					row = cols;
				}
				else
				{
					row++;
				}
				playFiled[col, row - 1] = '*';
			}

			return playFiled;
		}

		private static void smetki(char[,] pole)
		{
			int col = pole.GetLength(0);
			int row = pole.GetLength(1);

			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < row; j++)
				{
					if (pole[i, j] != '*')
					{
						char NeighbourMinesCounto = NeighbourMinesCount(pole, i, j);
						pole[i, j] = NeighbourMinesCounto;
					}
				}
			}
		}

		private static char NeighbourMinesCount(char[,] r, int rr, int rrr)
		{
			int count = 0;
			int rows = r.GetLength(0);
			int cols = r.GetLength(1);

			if (rr - 1 >= 0)
			{
				if (r[rr - 1, rrr] == '*')
				{ 
					count++; 
				}
			}
			if (rr + 1 < rows)
			{
				if (r[rr + 1, rrr] == '*')
				{ 
					count++; 
				}
			}
			if (rrr - 1 >= 0)
			{
				if (r[rr, rrr - 1] == '*')
				{ 
					count++;
				}
			}
			if (rrr + 1 < cols)
			{
				if (r[rr, rrr + 1] == '*')
				{ 
					count++;
				}
			}
			if ((rr - 1 >= 0) && (rrr - 1 >= 0))
			{
				if (r[rr - 1, rrr - 1] == '*')
				{ 
					count++; 
				}
			}
			if ((rr - 1 >= 0) && (rrr + 1 < cols))
			{
				if (r[rr - 1, rrr + 1] == '*')
				{ 
					count++; 
				}
			}
			if ((rr + 1 < rows) && (rrr - 1 >= 0))
			{
				if (r[rr + 1, rrr - 1] == '*')
				{ 
					count++; 
				}
			}
			if ((rr + 1 < rows) && (rrr + 1 < cols))
			{
				if (r[rr + 1, rrr + 1] == '*')
				{ 
					count++; 
				}
			}
			return char.Parse(count.ToString());
		}
	}
}
