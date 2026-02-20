using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int sizeArray = 10;
            int maxNumber = int.MinValue;
            int indexFirstNumber = 0;
            int numberMax = 100;

            Random randomNumber = new Random();
            int[,] numbers = new int[sizeArray, sizeArray];

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = randomNumber.Next(numberMax);
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
                        numbers[i, j] = indexFirstNumber;
                    }
                    Console.Write($"{numbers[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nмаксимальное значение ячейки - {maxNumber}");
        }
    }
}
