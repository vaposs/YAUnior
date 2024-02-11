namespace Exs_4;
using System.IO;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible= false;

        bool isPlaying = true;

        int pacmanX, pacmanY;
        int pacmanDX = 0, pacmanDY = 1;
        int allDots = 0;
        int collectDots = 0;

        char[,] map = ReadMap("GameMap", out pacmanX, out pacmanY, ref allDots);

        DrawMap(map);
        
        while (isPlaying)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Your dots: " + collectDots + "/" + allDots);
 
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ChangeDirection(key,ref pacmanDX, ref pacmanDY);
            }

            if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
            {
                Move(ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
                CollectDots (map, pacmanX, pacmanY, ref collectDots);
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
    
    static void Move (ref int X,ref int Y, int DX, int DY)
    {
        Console.SetCursorPosition(Y, X);
        Console.Write(" ");
        X += DX;
        Y += DY;

        Console.SetCursorPosition(Y,X);
        Console.Write('@');
    }
    
    static void CollectDots(char [,] map, int pacmanX, int pacmanY,ref int collectDots)
    {
        if (map[pacmanX, pacmanY] == '.')
        {
            collectDots++;
            map[pacmanX, pacmanY] = ' ';
        }
    }
    
    static void ChangeDirection (ConsoleKeyInfo key, ref int DX, ref int DY)
    {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                DX = -1; DY = 0;
                break;
            case ConsoleKey.DownArrow:
                DX = 1; DY = 0;
                break;
            case ConsoleKey.LeftArrow:
                DX = 0; DY = -1;
                break;
            case ConsoleKey.RightArrow:
                DX = 0; DY = 1;
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

                if (map[i, j] == '@')
                {
                    pacmanX = i;
                    pacmanY = j;
                }
                else if (map[i,j]==' ')
                {
                    map[i, j] = '.';
                    allDots++;
                }
            }
        }

        return map;
    }
}
