using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int positionX;
            int positionY;

            Console.Write("введите координату X - ");
            positionX = GetNumber();
            Console.Write("введите координату Y - ");
            positionY = GetNumber();
            Player player = new Player(positionX,positionY);

            Draw(player);
        }

        static int GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isSuccess;
            int number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isSuccess = int.TryParse(line, out number);

                if (isSuccess && number >= 0)
                {
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.WriteLine($" строка - {line}, не число или меньше  нуля. Повторите ввод. ");
                }
            }
            return number;
        }

        static void Draw(Player player)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if(i == player._positionX - 1 && j == player._positionY - 1)
                    {
                        Console.Write(player.playerIcon);
                    }
                    else
                    {
                        Console.Write("+");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Player
    {
        public char playerIcon = '@';
        public int _positionX = 0;
        public int _positionY = 0;

        public Player(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }
    }
}