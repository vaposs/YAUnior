using System;

namespace Project_6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int startingPoint = 0;
            int previousNumber = 1;
            int temporaryVariable = 0;
            int arraySize = 10;
            int randomMax = 100;
            Random random = new Random();
            int[] array = new int[arraySize];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(randomMax);
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - previousNumber])
                {
                    temporaryVariable = array[i];
                    array[i] = array[i - previousNumber];
                    array[i - previousNumber] = temporaryVariable;
                    i = startingPoint;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
        }
    }
}
