using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int sizeArray = 5;
            int maxNumber;
            int emptyNumber = 0;
            int numberMax = 100;

            Random number = new Random();
            int[,] array = new int[sizeArray, sizeArray];
            maxNumber = array[emptyNumber,emptyNumber];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j ++)
                {
                    array[i, j] = number.Next(numberMax);
                    Console.Write($"{array[i, j]} ");

                    if(array[i,j] > maxNumber)
                    {
                        maxNumber = array[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxNumber)
                    {
                        array[i, j] = emptyNumber;
                    }
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nмаксимальное значение ячейки - {maxNumber}");
        }
    }
}
