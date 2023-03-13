using System;
using System.Collections.Generic;

namespace Project_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int sizeArrayFirst;
            int sizeArraySecond;
            List<int> solution = new List<int>();

            Console.Write("Введите размер первого масива - ");
            sizeArrayFirst = GetNumber();
            Console.Write("Введите размер второго масива - ");
            sizeArraySecond = GetNumber();
            int[] arrayFirst = new int[sizeArrayFirst];
            int[] arraySecond = new int[sizeArraySecond];

            FillArray(arrayFirst);
            FillArray(arraySecond);
            TransferCollection(arrayFirst, solution);
            TransferCollection(arraySecond, solution);
            Console.Write("Первый масив - ");
            PrintArray(arrayFirst);
            Console.Write("\nВторой масив - ");
            PrintArray(arraySecond);
            Console.Write("\nРезультат - ");
            PrintList(solution);
        }

        static int GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isSuccess;
            int number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isSuccess = int.TryParse(line, out number);

                if (isSuccess && number >= 0)
                {
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.WriteLine($" строка - {line}, не число или меньше  нуля. Повторите ввод. ");
                }
            }
            return number;
        }

        static void FillArray(int[] array)
        {
            Random ramdom = new Random();
            int minimalRamdomNumber = 1;
            int maximalRamdomNumber = 10;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ramdom.Next(minimalRamdomNumber,maximalRamdomNumber);
            }
        }

        static void PrintList(List<int> solution)
        {
            foreach (var numb in solution)
            {
                Console.Write($"{numb} ,");
            }
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write($"{array[i]}");
                }
                else
                {
                    Console.Write($"{array[i]}, ");
                }
            }
        }

        static void TransferCollection(int[] array, List<int> solution)
        {
            for (int i = 0; i < (array.Length); i++)
            {
                if (solution.Contains(array[i]) == false)
                {
                        solution.Add(array[i]);
                }
            }
        }
    }
}