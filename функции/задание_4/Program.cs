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
            bool isFinish = true;
            uint size = 1;
            char blockIcon = '#';
            char heroIcon = '@';
            char coinIcon = '0';
            char emptyBlock = ' ';

            Console.Write("Введите размер поля - ");
            size = GetNumber();
            movesLeft = Convert.ToInt32(size + size);
            fild = new char[size, size];

            while (isFinish)
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
                isFinish = GameOver(movesLeft, isFinish, score);
            }
        }

        static void Move(char[,] fild, ref int heroPositionX, ref int heroPositionY, char blockIcon)
        {
            const ConsoleKey MoveUp = ConsoleKey.UpArrow;
            const ConsoleKey MoveDown = ConsoleKey.DownArrow;
            const ConsoleKey MoveRight = ConsoleKey.RightArrow;
            const ConsoleKey MoveLeft = ConsoleKey.LeftArrow;

            int nextPositionX;
            int nextPositionY;
            ConsoleKeyInfo charKey = Console.ReadKey();

            switch (charKey.Key)
            {
                case MoveUp:
                    nextPositionX = heroPositionX - 1;
                    GetMoves(MoveUp, MoveDown, MoveLeft, MoveRight, charKey ,fild,ref heroPositionX,ref heroPositionY, blockIcon);
                    break;
                case MoveDown:
                    nextPositionX = heroPositionX + 1;
                    GetMoves(MoveUp, MoveDown, MoveLeft, MoveRight, charKey, fild, ref heroPositionX, ref heroPositionY, blockIcon);
                    break;
                case MoveLeft:
                    nextPositionY = heroPositionY - 1;
                    GetMoves(MoveUp, MoveDown, MoveLeft, MoveRight, charKey, fild, ref heroPositionX, ref heroPositionY, blockIcon);
                    break;
                case MoveRight:
                    nextPositionY = heroPositionY + 1;
                    GetMoves(MoveUp, MoveDown, MoveLeft, MoveRight, charKey, fild, ref heroPositionX, ref heroPositionY, blockIcon);
                    break;
                default:
                    break;
            }
        }

        static void GetMoves(char[,] fild, int heroPositionX, int heroPositionY, char blokcIcon, ConsoleKey MoveUp, ConsoleKey MoveDown)
        {
            if()
            {

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
