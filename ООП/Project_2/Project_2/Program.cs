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
            positionPlayerX = GetNumber();
            Console.Write("Введите позицию игрока Y: ");
            positionPlayerY = GetNumber();
            Console.Clear();

            Render renderer = new Render();
            Player player = new Player(positionPlayerX, positionPlayerY);

            renderer.DrawPlayer(player.PositionX, player.PositionY);
        }

        static int GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isSuccess;
            int number = 0;

            while (isConversionSucceeded)
            {
                Console.Write("введите целое число - ");
                line = Console.ReadLine();
                isSuccess = int.TryParse(line, out number);

                if (isSuccess)
                {
                    if(number < 0)
                    {
                        Console.WriteLine($"число {number} меньше нуля, введите другое число");
                    }
                    else
                    {
                        isConversionSucceeded = false;
                    }
                }
                else
                {
                    Console.WriteLine($"строка {line} не может быть конвертирована в число");
                }
            }
            return number;
        }
    }

    class Render
    {
        public void DrawPlayer(int positionX, int positionY, char playerIcon = '@')
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(playerIcon);
        }
    }

    class Player
    {
        public int PositionX { get; private set; }

        public int PositionY { get; private set; }

        public Player(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}