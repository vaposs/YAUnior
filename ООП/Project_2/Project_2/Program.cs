using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            char playerIcon = '@';

            Console.Write("Введите позицию игрока X: ");
            int positionPlayerX = GetNumber();

            Console.Write("Введите позицию игрока Y: ");
            int positionPlayerY = GetNumber();

            Console.Clear();

            Renderer renderer = new Renderer();
            Player player = new Player(positionPlayerX, positionPlayerY, playerIcon);

            renderer.DrawPlayer(player);
        }

        static int GetNumber()
        {
            bool isNumberValid = false;
            int result = 0;

            while (isNumberValid == false)
            {
                Console.Write("введите целое число - ");
                string line = Console.ReadLine();

                if (int.TryParse(line, out int number))
                {
                    if (number < 0)
                    {
                        Console.WriteLine($"число {number} меньше нуля, введите другое число");
                    }
                    else
                    {
                        result = number;
                        isNumberValid = true;
                    }
                }
                else
                {
                    Console.WriteLine($"строка {line} не может быть конвертирована в число");
                }
            }

            return result;
        }
    }

    class Renderer
    {
        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.Write(player.Icon);
        }
    }

    class Player
    {
        public Player(int positionX, int positionY, char icon)
        {
            PositionX = positionX;
            PositionY = positionY;
            Icon = icon;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Icon { get; private set; }
    }
}
