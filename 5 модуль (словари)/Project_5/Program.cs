using System;
using System.Collections.Generic;

namespace Project_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int firstArraySize;
            int secondArraySize;
            List<int> uniqueNumbers = new List<int>();

            Console.Write("Введите размер первого массива - ");
            firstArraySize = GetNumber();
            Console.Write("Введите размер второго массива - ");
            secondArraySize = GetNumber();

            int[] firstArray = new int[firstArraySize];
            int[] secondArray = new int[secondArraySize];

            FillArray(firstArray);
            FillArray(secondArray);

            AddUniqueElements(firstArray, uniqueNumbers);
            AddUniqueElements(secondArray, uniqueNumbers);

            Console.Write("Первый массив - ");
            PrintArray(firstArray);
            Console.Write("\nВторой массив - ");
            PrintArray(secondArray);
            Console.Write("\nРезультат - ");
            PrintList(uniqueNumbers);
        }

        static int GetNumber()
        {
            string userInput;
            bool isConversionSucceeded = true;
            bool isParsingSuccessful;
            int number = 0;

            while (isConversionSucceeded)
            {
                userInput = Console.ReadLine();
                isParsingSuccessful = int.TryParse(userInput, out number);

                if (isParsingSuccessful && number >= 0)
                {
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.WriteLine($"Строка '{userInput}' не является числом или меньше нуля. Повторите ввод.");
                }
            }
            return number;
        }

        static void FillArray(int[] array)
        {
            Random randomGenerator = new Random();
            int minimumRandomValue = 1;
            int maximumRandomValue = 10;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomGenerator.Next(minimumRandomValue, maximumRandomValue);
            }
        }

        static void PrintList(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write($"{number}, ");
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

        static void AddUniqueElements(int[] sourceArray, List<int> targetList)
        {
            for (int i = 0; i < sourceArray.Length; i++)
            {
                int currentElement = sourceArray[i];

                if (targetList.Contains(currentElement) == false)
                {
                    targetList.Add(currentElement);
                }
            }
        }
    }
}
