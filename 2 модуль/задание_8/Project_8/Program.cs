using System;

namespace Project_8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int sizeArray = 4;
            int[] array = new int[sizeArray];
            int beginNumber;
            int shift = 1;

            Console.Write("\nпервоначальный масив ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
                Console.Write(array[i] + ",");
            }

            Console.Write("\nна сколько елементов сдвинуть? - ");
            shift = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < shift % sizeArray; i++)
            {
                beginNumber = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = beginNumber;
            }

            Console.Write("результат - ");

            for (int i = 0; i < array.Length; i++)
            {
                    Console.Write(array[i] + ",");
            }
        }
    }
}
