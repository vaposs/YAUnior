using System;

namespace Project_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            int movesLeft;
            int coinPrice = 5;
            int score = 0;
            char[,] fild;
            int heroPositionX = 4;
            int heroPositionY = 4;
            uint positionCoinX = 1;
            uint positionCoinY = 1;
            bool isEnableCoin = false;
            bool OverGame = true;
            uint size = 1;
            char blockIcon = '#';
            char heroIcon = '@';
            char coinIcon = '0';
            char emptyBlock = ' ';

            Console.Write("Введите размер поля - ");
            size = GetNumber();
            movesLeft = Convert.ToInt32(size + size);
            fild = new char[size, size];

            while (OverGame)
            {
                Console.Clear();

                isEnableCoin =  GetNextCoin(isEnableCoin, ref positionCoinX, ref positionCoinY, heroPositionX, heroPositionY, size);

                FillArray(fild, size, positionCoinX, positionCoinY, heroPositionX, heroPositionY, coinIcon, blockIcon, heroIcon, emptyBlock);
                PrintArray(fild);
                PrintScore(score);
                PrintMove(ref movesLeft);
                Move(fild, ref heroPositionX, ref heroPositionY, blockIcon);

                if (positionCoinX == heroPositionX && positionCoinY == heroPositionY)
                {
                    score++;
                    movesLeft = movesLeft + coinPrice;
                    isEnableCoin = false;
                }
                OverGame = GameOver(movesLeft, OverGame, score);
            }
        }

        static void Move(char[,] fild, ref int heroPositionX, ref int heroPositionY, char blockIcon)
        {
            const ConsoleKey MoveUp = ConsoleKey.UpArrow;
            const ConsoleKey MoveDown = ConsoleKey.DownArrow;
            const ConsoleKey MoveRight = ConsoleKey.RightArrow;
            const ConsoleKey MoveLeft = ConsoleKey.LeftArrow;

            ConsoleKeyInfo charKey = Console.ReadKey();

            switch (charKey.Key)
            {
                case MoveUp:
                    GetMoves(MoveUp, MoveDown, MoveLeft, MoveRight, charKey ,fild,ref heroPositionX,ref heroPositionY, blockIcon);
                    break;
                case MoveDown:
                    GetMoves(MoveUp, MoveDown, MoveLeft, MoveRight, charKey, fild, ref heroPositionX, ref heroPositionY, blockIcon);
                    break;
                case MoveLeft:
                    GetMoves(MoveUp, MoveDown, MoveLeft, MoveRight, charKey, fild, ref heroPositionX, ref heroPositionY, blockIcon);
                    break;
                case MoveRight:
                    GetMoves(MoveUp, MoveDown, MoveLeft, MoveRight, charKey, fild, ref heroPositionX, ref heroPositionY, blockIcon);
                    break;
                default:
                    break;
            }
        }

        static void GetMoves(ConsoleKey MoveUp, ConsoleKey MoveDown, ConsoleKey MoveLeft, ConsoleKey MoveRight, ConsoleKeyInfo charKey , char[,] fild,ref int heroPositionX,ref  int heroPositionY, char blockIcon)
        {
            if ((fild[heroPositionX - 1, heroPositionY] != blockIcon)&&(MoveUp == charKey.Key))
            {
                heroPositionX--;
            }
            else if ((fild[heroPositionX + 1, heroPositionY] != blockIcon)&&(MoveDown == charKey.Key))
            {
                 heroPositionX++;
            }
            else if ((fild[heroPositionX, heroPositionY - 1] != blockIcon)&&(MoveLeft == charKey.Key))
            {
                  heroPositionY--;
            }
            else if ((fild[heroPositionX, heroPositionY + 1] != blockIcon)&&( MoveRight == charKey.Key))
            {
                  heroPositionY++;
            }
        }

        static void FillArray(char[,] fild, uint size, uint positionCoinX, uint positionCoinY, int heroPositionX, int heroPositionY, char coinIcon, char blockIcon, char heroIcon, char emptyBlock)
        {
            for (int i = 0; i < fild.GetLength(0); i++)
            {
                for (int j = 0; j < fild.GetLength(1); j++)
                {
                    if (positionCoinX == i && positionCoinY == j)
                    {
                        fild[i, j] = coinIcon;
                    }
                    else if (i == 0 || j == 0)
                    {
                        fild[i, j] = blockIcon;
                    }
                    else if (i == (size - 1) || j == (size - 1))
                    {
                        fild[i, j] = blockIcon;
                    }
                    else if (i == heroPositionX && j == heroPositionY)
                    {
                        fild[i, j] = heroIcon;
                    }
                    else
                    {
                        fild[i, j] = emptyBlock;
                    }
                }
            }
        }

        static void PrintArray(char[,] fild)
        {
            for (int i = 0; i < fild.GetLength(0); i++)
            {
                for (int j = 0; j < fild.GetLength(1); j++)
                {
                    Console.Write(fild[i, j]);
                }
                Console.WriteLine("");
            }
        }

        static uint GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isSuccess;
            uint number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isSuccess = uint.TryParse(line, out number);

                if (isSuccess)
                {
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.Write($"неверное значение {line}, введите другое число - ");
                }
            }
            return number;
        }

        static uint GetRandomNumber(uint sizeArray)
        {
            uint number = 0;
            uint minRandom = 1;
            uint maxRandom = sizeArray - 1;
            int minRandomInt = Convert.ToInt32(minRandom);
            int maxRandomInt = Convert.ToInt32(maxRandom);
            Random randomNumber = new Random();

            number = Convert.ToUInt32(randomNumber.Next(minRandomInt, maxRandomInt));
            return number;
        }

        static bool GameOver(int move, bool OverGame, int score)
        {
            if (move <= 1)
            {
                OverGame = false;
                Console.Clear();
                Console.WriteLine($"Игра закончена, ваш счет - {score}");
            }
            return OverGame;
        }

        static void PrintScore(int score)
        {
            Console.WriteLine($"счет - {score}");
        }

        static void PrintMove(ref int movesLeft)
        {
            movesLeft--;
            Console.Write($"Осталсь ходов - {movesLeft}");
        }

        static bool GetNextCoin(bool isEnableCoin, ref uint positionCoinX, ref uint positionCoinY, int heroPositionX, int heroPositionY, uint size)
        {
            if (isEnableCoin == false)
            {
                positionCoinX = GetRandomNumber(size);
                positionCoinY = GetRandomNumber(size);

                if (heroPositionX == positionCoinX && heroPositionY == positionCoinY)
                {
                    positionCoinX = GetRandomNumber(size);
                    positionCoinY = GetRandomNumber(size);
                }
                isEnableCoin = true;
            }
            return isEnableCoin;
        }
    }
}
