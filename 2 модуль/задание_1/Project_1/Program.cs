using System;

namespace Project_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int arrayLine = 2;
            int arrayColumn = 5;
            int randomMax = 10;
            int initialУlement = 0;
            int nextElement = 1;
            int summ = 0;
            int a = 0;

            int[,] array = new int[arrayLine,arrayColumn];
            int[] arrayResult = new int[arrayColumn];
            Random numner = new Random();

            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = numner.Next(randomMax);
                    Console.Write(array[i,j]+ " ");
                }
                Console.Write("\n");
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                summ += array[a, i];
                array[a, i] = array[initialУlement, i] * array[initialУlement + nextElement, i];
                Console.Write(array[a, i] + " ");
            }
            Console.WriteLine($"\nсума первой строки - {summ}");
        }
    }
}
