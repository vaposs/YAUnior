using System;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int sizeArray = 10;
            int maxNumber = 0;
            int emptyNumber = 0;

            Random number = new Random();
            int[,] array = new int[sizeArray, sizeArray];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j ++)
                {
                    array[i, j] = number.Next(100);
                    Console.Write($"{array[i, j]} ");

                    if(array[i,j] > maxNumber)
                    {
                        maxNumber = array[i, j];
                        array[i, j] = emptyNumber;
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n");


            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nмаксимальное значение ячейки - {maxNumber}");
        }
    }
}
