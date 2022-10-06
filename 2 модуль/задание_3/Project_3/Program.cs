using System;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int arraySize = 30;
            int nextOrPrevious = 1;
            int[] array = new int[arraySize];
            Random rand = new Random();

            for(int i = 0; i < array.Length; i ++)
            {
                array[i] = rand.Next(100);
                Console.Write(array[i] + ",");
            }

            Console.WriteLine("Hello World!");

            for (int i = 0; i < array.Length; i++ )
            {
                if (i == 0)
                {
                    if (array[nextOrPrevious] < array[i])
                    {
                        Console.Write(array[i] + ",");
                    }
                }
                else if (i == (arraySize - nextOrPrevious))
                {
                    Console.Write(array[i] + ",");
                }
                else if(array[i - nextOrPrevious] < array[i] && array[i + nextOrPrevious] < array[i])
                {
                    Console.Write(array[i] + ",");
                }
            }
        }
    }
}
