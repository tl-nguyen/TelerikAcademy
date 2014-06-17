using System;
using System.Threading;

struct Rock
{
    public int colPos;
    public int rowPos;
    public int type;

    public Rock(int colPos, int rowPos, int type)
    {
        this.colPos = colPos;
        this.rowPos = rowPos;
        this.type = type;
    }
}

class FallingRocks
{
    //Constants
    const String PLAYER = "(0)";
    const int PLAYFIELD_OFFSET_RIGHT = 30;
    const int PLAYFIELD_OFFSET_LEFT = 1;
    const int MAX_SLOW_MOTION_DURATION = 10;

    //Player info
    static int playerPosition = ((Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT) / 2)
                                - (PLAYER.Length / 2);
    static int lives = 5;
    static int gamesWonWithoutDying = 0;

    //Rocks info
    static Rock[] rocks = new Rock[10];
    static char[] rockTypes = new char[] { '@', '*', '&', '+', '%', '$'
                                            , '#', '!', '.', ';', '-' };
    static int maxRocksPerRow = 2;
    static int currentRockIndex = 0;
    static int rocksPerCurrentRow;
    static int fallenRocks = 0;

    //Game info										
    static int gameSpeed = 150;
    static int slowMotionSpeed = gameSpeed;
    static int slowMotionTimer = 0;
    static int level = 1;

    static Random randomGenerator = new Random();

    static void Main()
    {
        SetConsoleWindow();

        while(true)
        {
            if (Console.KeyAvailable)
            {
                GameControl();
            }
            Console.Clear();
            DrawPlayer();
            DrawRocks();
            DrawGameInfo();
            if (fallenRocks == rocks.Length)
            {
                WinningMessageAndLevelUp();
            }
            SetGameSpeed();
        }
    }

    static void SetConsoleWindow()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    static void GameControl()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
        if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            MovePlayerLeft();
        }
        if (keyInfo.Key == ConsoleKey.RightArrow)
        {
            MovePlayerRight();
        }
        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            SlowItDown();
        }
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            GetDefaultSpeed();
        }
    }

    static void MovePlayerLeft()
    {
        if (playerPosition > PLAYFIELD_OFFSET_LEFT + 1)
        {
            playerPosition--;
        }
    }

    static void MovePlayerRight()
    {
        if (playerPosition < Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT - PLAYER.Length)
        {
            playerPosition++;
        }
    }

    static void SlowItDown()
    {
        slowMotionTimer = MAX_SLOW_MOTION_DURATION;
    }

    static void GetDefaultSpeed()
    {
        slowMotionTimer = 0;
    }

    static void DrawPlayer()
    {
        ChangeColor(ConsoleColor.Yellow);
        PrintAtPosition(playerPosition, Console.WindowHeight - 1, PLAYER);
    }

    static void DrawRocks()
    {
        ChangeColor(ConsoleColor.Red);
        rocksPerCurrentRow = randomGenerator.Next(1, maxRocksPerRow + 1);
        SetNewRocks();
        MoveRocksDown();
        currentRockIndex += rocksPerCurrentRow;

        for (int i = fallenRocks; i <= currentRockIndex; i++)
        {
            if (rocks[i].rowPos == Console.WindowHeight - 1)
            {
                CollisionHandler(rocks[i].colPos);
                if (lives < 1)
                {
                    LosingMessageAndLevelDown();
                    lives = 1;
                    break;
                }
                fallenRocks++;
            }
            PrintAtPosition(rocks[i].colPos
                            , rocks[i].rowPos
                            , rockTypes[rocks[i].type]);
        }
    }

    static void SetNewRocks()
    {
        if (currentRockIndex + rocksPerCurrentRow >= rocks.Length)
        {
            rocksPerCurrentRow = rocks.Length - currentRockIndex - 1;
        }

        for (int i = (currentRockIndex == 0) ? currentRockIndex : (currentRockIndex + 1)
             ; i <= currentRockIndex + rocksPerCurrentRow && i < rocks.Length
             ; i++)
        {
            rocks[i] = new Rock(randomGenerator.Next(PLAYFIELD_OFFSET_LEFT + 1
                                                     , Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT)
                                , 0
                                , randomGenerator.Next(0, rockTypes.Length));
        }
    }

    static void MoveRocksDown()
    {
        for (int i = fallenRocks; i <= currentRockIndex; i++)
        {
            if (rocks[i].rowPos < Console.WindowHeight - 1)
            {
                rocks[i].rowPos++;
            }
        }
    }

    static void CollisionHandler(int colPosition)
    {
        Boolean hasCollision = (colPosition == playerPosition
                                || colPosition == playerPosition + 1
                                || colPosition == playerPosition + 2);
        if (hasCollision)
        {
            Console.Beep();
            lives--;
            slowMotionTimer = MAX_SLOW_MOTION_DURATION;
            slowMotionSpeed = gameSpeed;
            gamesWonWithoutDying = 0;
        }
    }

    static void PrintAtPosition(int col, int row, char symbol)
    {
        Console.SetCursorPosition(col, row);
        Console.Write(symbol);
    }

    static void PrintAtPosition(int col, int row, String message)
    {
        Console.SetCursorPosition(col, row);
        Console.Write(message);
    }

    static void DrawGameInfo()
    {
        DrawScore();
        DrawLives();
        DrawLevel();
        DrawInstruction();
        DrawPlayField();
    }

    static void DrawScore()
    {
        ChangeColor(ConsoleColor.Magenta);
        PrintAtPosition((Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT)/2 - 10
                        , 2
                        , "Your Score is (" + fallenRocks + "/" + rocks.Length + ")");
    }

    static void DrawLives()
    {
        if (lives > 0) 
            ChangeColor(ConsoleColor.Cyan);
        else 
            ChangeColor(ConsoleColor.Red);

        PrintAtPosition(0, 0, 'L');
        PrintAtPosition(0, 1, 'I');
        PrintAtPosition(0, 2, 'V');
        PrintAtPosition(0, 3, 'E');
        PrintAtPosition(0, 4, 'S');
        PrintAtPosition(0, 5, '-');

        if (lives < 2) 
            ChangeColor(ConsoleColor.Red);
        else if (lives >= 2 && lives < 5) 
            ChangeColor(ConsoleColor.Yellow);
        else
            ChangeColor(ConsoleColor.Green);

        for (int i = 0; i < lives; i++)
        {
            Console.Write("\n*");
        }
    }

    static void DrawPlayField()
    {
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            ChangeColor(ConsoleColor.Blue);
            PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT, i, '|');
            PrintAtPosition(PLAYFIELD_OFFSET_LEFT, i, '|');
        }
    }

    static void DrawLevel()
    {
        ChangeColor(ConsoleColor.Cyan);
        PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 11
                        , 1
                        , "Level " + level);
    }

    static void DrawInstruction()
    {
        ChangeColor(ConsoleColor.White);
        PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 9
                        , Console.WindowHeight -5
                        , "Slow It Down");
        PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 14
                        , Console.WindowHeight -4
                        , "^");
        PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 14
                        , Console.WindowHeight -3
                        , "|");
        PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 2
                        , Console.WindowHeight - 2
                        , "Move Left <- -> Move Right");
    }

    static void SetGameSpeed()
    {
        if (slowMotionTimer > 0)
        {
            SlowMotionMode();
        }
        else
        {
            Thread.Sleep(gameSpeed);
        }
    }

    static void SlowMotionMode()
    {
        if (slowMotionTimer > MAX_SLOW_MOTION_DURATION / 2)
        {
            slowMotionSpeed = slowMotionSpeed + 20;
            Thread.Sleep(slowMotionSpeed);
        }
        else
        {
            slowMotionSpeed = slowMotionSpeed - 20;
            Thread.Sleep(slowMotionSpeed);
        }
        slowMotionTimer--;
    }

    static void WinningMessageAndLevelUp()
    {
        LevelUp();
        gamesWonWithoutDying++;
        
        if (level % 3 == 0)
        {
            ChangeColor(ConsoleColor.Cyan);
            int bonusLives = (gamesWonWithoutDying + 1 <= 2) ? 1 : (gamesWonWithoutDying + 1) / 2;
            lives += bonusLives;
            PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 3
                            , 8
                            , "!!! Bonus lives : +" + bonusLives +" !!!");
        }
        ChangeColor(ConsoleColor.Green);
        PrintEndMessage("WON \\m/");
    }

    static void LosingMessageAndLevelDown()
    {
        DrawGameInfo();
        if (level == 1)
        {
            SetNewGame(rocks.Length, maxRocksPerRow, gameSpeed);
        }
        else
        {
            LevelDown();
        }
        ChangeColor(ConsoleColor.DarkRed);
        PrintEndMessage("LOST :(");
    }

    static void PrintEndMessage(String gameResult)
    {
        PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 10
                        , 6
                        , "YOU " + gameResult);
        PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 3
                        , 10
                        , "Coming up next = Level " + (level == 0 ? 1 : level));
        PrintAtPosition(Console.WindowWidth - PLAYFIELD_OFFSET_RIGHT + 2
                        , 12
                        , "Press any key to continue...");
        PrintAtPosition(Console.WindowWidth - 28
                        , 13
                        , "...or [ESC] to exit\n");
        ConsoleKeyInfo decisionKey = Console.ReadKey();
        if (decisionKey.Key == ConsoleKey.Escape)
        {
            ExitGame();
        }
    }

    static void LevelUp()
    {
        level++;
        SetNewGame((int)(rocks.Length * 1.5)
                    , (int)(maxRocksPerRow * 1.2)
                    , (int)(gameSpeed / 1.2));
    }

    static void LevelDown()
    {
        level--;
        SetNewGame((int)(rocks.Length / 1.5)
                    , (int)(maxRocksPerRow / 1.2)
                    , (int)(gameSpeed * 1.2));
    }

    static void SetNewGame(int rockAmount, int newMaxRocksPerRow, int newGamespeed)
    {
        currentRockIndex = 0;
        fallenRocks = 0;
        rocks = new Rock[rockAmount];
        maxRocksPerRow = newMaxRocksPerRow;
        gameSpeed = newGamespeed;
    }

    static void ChangeColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    static void ExitGame()
    {
        Environment.Exit(0);
    }
}

