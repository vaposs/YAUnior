namespace Exs_4;
using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        const char player = '@';
        const char dots = '.';
        const char space = ' ';
        const char wall = '#';

        Console.CursorVisible= false;

        bool isPlaying = true;

        int pacmanX;
        int pacmanY;
        int directionX = 0;
        int directionY = 0;
        int allDots = 0;
        int collectDots = 0;
 
        char[,] map = ReadMap("GameMap", out pacmanX, out pacmanY, ref allDots, player, dots, space);

        DrawMap(map);
        
        while (isPlaying)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Your dots: " + collectDots + "/" + allDots);
 
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ChangeDirection(key,ref directionX, ref directionY);
            }

            if (map[pacmanX + directionX, pacmanY + directionY] != wall)
            {
                Move(ref pacmanX, ref pacmanY, directionX, directionY, space, player);
                CollectDots (map, pacmanX, pacmanY, ref collectDots,dots,space);
            }

            System.Threading.Thread.Sleep(200);

            if (collectDots==allDots)
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

    static void Move (ref int positionX,ref int positionY, int directionX, int directionY, char space, char player)
    {
        Console.SetCursorPosition(positionY, positionX);
        Console.Write(space);
        positionX += directionX;
        positionY += directionY;
      
        Console.SetCursorPosition(positionY, positionX);
        Console.Write(player);
    }

    static void CollectDots(char [,] map, int pacmanX, int pacmanY,ref int collectDots, char dots, char space)
    {
        if (map[pacmanX, pacmanY] == dots)
        {
            collectDots++;
            map[pacmanX, pacmanY] = space;
        }
    }

    static void ChangeDirection (ConsoleKeyInfo key, ref int directionX, ref int directionY)
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

    static char[,] ReadMap(string mapName, out int pacmanX, out int pacmanY, ref int allDots, char player,char dots, char space)
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

                if (map[i, j] == player)
                {
                    pacmanX = i;
                    pacmanY = j;
                }
                else if (map[i,j]==space)
                {
                    map[i, j] = dots;
                    allDots++;
                }
            }
        }

        return map;
    }
}
