using System;

namespace Project_8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] array = new int[10];
            int beginNamber;
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
                beginNamber = array[0];

                for (int i = 0; i < array.Length; i ++)
                {
                    if(i == array.Length - 1)
                    {
                        array[i] = beginNamber;
                    }
                    else
                    {
                        array[i] = array[i + 1];
                    }
                }

                shift--;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ",");
            }
        }
    }
}
