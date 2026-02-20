using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int matrixSide = 10;
            int maxNumber = int.MinValue;
            int replacementValue = 0;
            int maxRandomValue = 100;

            Random randomNumber = new Random();
            int[,] numbers = new int[matrixSide, matrixSide];

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = randomNumber.Next(maxRandomValue);
                    Console.Write($"{numbers[i, j]} ");

                    if (numbers[i, j] > maxNumber)
                    {
                        maxNumber = numbers[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (numbers[i, j] == maxNumber)
                    {
                        numbers[i, j] = replacementValue;
                    }
                    Console.Write($"{numbers[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nмаксимальное значение ячейки - {maxNumber}");
        }
    }
}
