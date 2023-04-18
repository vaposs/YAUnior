using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int positionPlayerX;
            int positionPlayerY;

            Console.Write("Введите позицию игрока X: ");
            positionPlayerX = Convert.ToInt32(Console.ReadLine()); 
            Console.Write("Введите позицию игрока Y: ");
            positionPlayerY = Convert.ToInt32(Console.ReadLine());

            Render renderer = new Render();
            Player player = new Player(positionPlayerX, positionPlayerY);

            renderer.DrawPlayer(player.GetX(),player.GetY());
        }
    }

    class Render
    {
        public void DrawPlayer(int x, int y, char playerIcon = '@')
        {
            Console.SetCursorPosition(x,y);
            Console.Write(playerIcon);
        }
    }

    class Player
    {
        private int _x;
        private int _y;

        public Player(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }
    }
}