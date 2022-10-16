using System;

namespace Project_8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int sizeArray = 10;
            int[] array = new int[sizeArray];
            int beginNumber;
            int shift = 1;

            Console.Write("первоначальный масив ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
                Console.Write(array[i] + ",");
            }

            Console.Write("\nна сколько елементов сдвинуть? - ");
            shift = Convert.ToInt32(Console.ReadLine());

            while (shift > 0)
            {
                beginNumber = array[0];

                for (int i = 0; i < array.Length - 1; i ++)
                {
                    array[i] = array[i + 1];
                }

                array[array.Length - 1] = beginNumber;
                shift--;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
        }
    }
}
