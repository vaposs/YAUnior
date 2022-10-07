using System;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int arraySize = 30;
            int arrayBegin = 0;
            int nextOrPrevious = 1;
            int numberMax = 100;
            int[] array = new int[arraySize];
            Random random = new Random();

            int arrayLast = arraySize - nextOrPrevious;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(numberMax);
                Console.Write(array[i] + ",");
            }

            Console.Write("\n\n");

            if (array[arrayBegin + nextOrPrevious] < array[arrayBegin])
            {
                Console.Write(array[arrayBegin] + ",");
            }

            if (array[arrayLast] > array[arrayLast - nextOrPrevious])
            {
                Console.Write(array[arrayLast] + ",");
            }
       
            for (int i = 1; i < array.Length - 1; i++ )
            {
                if(array[i] > array[i + nextOrPrevious] && array[i] > array[i - nextOrPrevious])
                {
                    Console.Write(array[i] + ",");
                }
            }
        }
    }
}
