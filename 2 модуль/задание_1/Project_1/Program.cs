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

            int[,] masiv = new int[arrayLine,arrayColumn];
            int[] arrayResult = new int[arrayColumn];
            Random numner = new Random();

            for(int i = 0; i < masiv.GetLength(0); i++)
            {
                for(int j = 0; j < masiv.GetLength(1); j++)
                {
                    masiv[i,j] = numner.Next(randomMax);
                    Console.Write(masiv[i,j]+ " ");
                }
                Console.Write("\n");
            }

            for(int j = 0; j < arrayResult.Length; j++)
            {
                arrayResult[j] = masiv[initialУlement, j] + masiv[initialУlement + nextElement, j];
                Console.Write(arrayResult[j] + " ");
            }
        }
    }
}
