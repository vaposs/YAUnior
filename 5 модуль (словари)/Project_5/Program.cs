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
            int[] mergeArray = new int[sizeArrayFirst + sizeArraySecond];

            FillArray(ref arrayFirst);
            FillArray(ref arraySecond);
            MergeArrays(ref arrayFirst, ref arraySecond, ref mergeArray);
            BubbleSort(ref mergeArray);
            TransferCollection(ref mergeArray, solution);
            Console.Write("Результат - ");
            PrintSolution(solution);
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

        static void MergeArrays(ref int[] arrayFirst, ref int[] arraySecond, ref int[] MergeArray)
        {
            for (int i = 0; i < MergeArray.Length; i++)
            {
                if (i < arrayFirst.Length)
                {
                    MergeArray[i] = arrayFirst[i];
                }
                else
                {
                    MergeArray[i] = arraySecond[i - arrayFirst.Length];
                }

            }
        }

        static void FillArray(ref int[] arrays)
        {
            Random numb = new Random();
            int minRan = 1;
            int maxRan = 10;

            for (int i = 0; i < arrays.Length; i++)
            {
                arrays[i] = numb.Next(minRan,maxRan);
            }
        }

        static void PrintSolution(List<int> solution)
        {
            foreach (var numb in solution)
            {
                Console.Write($"{numb} ,");
            }
        }

        static void BubbleSort(ref int[] array)
        {
            int tempСell;

            for (int i = 0; i < array.Length- 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[i] > array[i + 1])
                    {
                        tempСell = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tempСell;
                        i = 0;
                    }
                }
            }
        }

        static void TransferCollection(ref int[] array, List<int> solution)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(solution.Contains(array[i]) == false)
                {
                    solution.Add(array[i]);
                }
            }
        }
    }
}
