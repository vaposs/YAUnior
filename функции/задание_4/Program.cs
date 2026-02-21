using System.IO;
using System;

class Program
{
    private const char Player = '@';
    private const char Dots = '.';
    private const char Space = ' ';
    private const char Wall = '#';
    private const string MapFileName = "GameMap";

    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        bool isPlaying = true;
        int pacmanX;
        int pacmanY;
        int allDots = 0;
        int collectDots = 0;

        char[,] map = ReadMap(MapFileName, out pacmanX, out pacmanY, ref allDots);

        DrawMap(map);

        while (isPlaying)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"Your dots: {collectDots}/{allDots}");

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                GetDirection(key, out int directionX, out int directionY);

                if (map[pacmanX + directionX, pacmanY + directionY] != Wall)
                {
                    Move(ref pacmanX, ref pacmanY, directionX, directionY);
                    CollectDots(map, pacmanX, pacmanY, ref collectDots);
                }
            }

            System.Threading.Thread.Sleep(200);

            if (collectDots == allDots)
            {
                isPlaying = false;
            }
        }

        Console.SetCursorPosition(0, 21);

        if (collectDots == allDots)
        {
            Console.WriteLine("You win!");
            Console.ReadKey();
        }
    }

    static void Move(ref int positionX, ref int positionY, int directionX, int directionY)
    {
        Console.SetCursorPosition(positionY, positionX);
        Console.Write(Space);

        positionX += directionX;
        positionY += directionY;

        Console.SetCursorPosition(positionY, positionX);
        Console.Write(Player);
    }

    static void CollectDots(char[,] map, int pacmanX, int pacmanY, ref int collectDots)
    {
        if (map[pacmanX, pacmanY] == Dots)
        {
            collectDots++;
            map[pacmanX, pacmanY] = Space;
        }
    }

    static void GetDirection(ConsoleKeyInfo key, out int directionX, out int directionY)
    {
        directionX = 0;
        directionY = 0;

        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                directionX = -1;
                break;
            case ConsoleKey.DownArrow:
                directionX = 1;
                break;
            case ConsoleKey.LeftArrow:
                directionY = -1;
                break;
            case ConsoleKey.RightArrow:
                directionY = 1;
                break;
        }
    }

    static void DrawMap(char[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }

    static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY, ref int allDots)
    {
        pacmanX = 0;
        pacmanY = 0;

        string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
        char[,] map = new char[newFile.Length, newFile[0].Length];

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = newFile[i][j];

                if (map[i, j] == Player)
                {
                    pacmanX = i;
                    pacmanY = j;
                }
                else if (map[i, j] == Space)
                {
                    map[i, j] = Dots;
                    allDots++;
                }
            }
        }

        return map;
    }
}
