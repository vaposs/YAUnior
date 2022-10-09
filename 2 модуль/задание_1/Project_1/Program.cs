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
            int summ = 0;
            int derivatives = 1;
            int initialColumn = 0;
            int initialString = 1;
            int[,] array = new int[arrayLine,arrayColumn];
            Random number = new Random();

            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = number.Next(randomMax);
                    Console.Write(array[i,j]+ " ");
                }

                Console.Write("\n");
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                summ += array[initialString, i];
            }

            for(int i = 0; i < array.GetLength(0); i++)
            {
                derivatives *= array[i,initialColumn];
            }

            Console.WriteLine($"\nпроизведения первого столбца - {derivatives}");
            Console.WriteLine($"сума второй строки - {summ}");
        }
    }
}
