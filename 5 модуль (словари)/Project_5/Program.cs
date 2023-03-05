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
            TransferCollection(arrayFirst, arraySecond, solution);
            Console.Write("Результат - ");
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

        static void FillArray(int[] arrays)
        {
            Random numb = new Random();
            int minRan = 1;
            int maxRan = 10;

            for (int i = 0; i < arrays.Length; i++)
            {
                arrays[i] = numb.Next(minRan,maxRan);
            }
        }

        static void PrintList(List<int> solution)
        {
            foreach (var numb in solution)
            {
                Console.Write($"{numb} ,");
            }
        }

        static void TransferCollection(int[] arrayFirst, int[] arraySecond, List<int> solution)
        {
            for (int i = 0; i < (arrayFirst.Length + arraySecond.Length); i++)
            {
                if(i < arrayFirst.Length)
                {
                    if (solution.Contains(arrayFirst[i]) == false)
                    {
                        solution.Add(arrayFirst[i]);
                    }
                }
                else
                {
                    if (solution.Contains(arraySecond[i - arrayFirst.Length]) == false)
                    {
                        solution.Add(arraySecond[i - arrayFirst.Length]);
                    }
                }
            }
        }
    }
}