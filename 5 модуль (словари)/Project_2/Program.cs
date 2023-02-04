using System;
using System.Collections.Generic;
using System.Globalization;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Queue<int> checks = new Queue<int>();
            Console.Write("Введите количество чеков в очереди - ");

            int maxChecks = GetNumber();
            CreateQueue(checks, maxChecks);
            Print(checks, maxChecks);
        }

        static void CreateQueue(Queue<int> checks, int maxChecks)
        {
            int randomNumb;

            Console.Write("Введите минимальную сумму чека - ");
            int minNumb = GetNumber();
            Console.Write("Введите максимальную сумму чека - ");
            int maxNumb = GetNumber();

            for (int i = 0; i < maxChecks; i++)
            {
                randomNumb = GetRandomNumber(minNumb, maxNumb);
                checks.Enqueue(randomNumb);
            }
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

                if (isSuccess)
                {
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.WriteLine($" строка - {line}, не число. Повторите ввод. ");
                }
                number = Convert.ToInt32(line);

                if(number < 0)
                {
                    isConversionSucceeded = true;
                    Console.WriteLine($"Число {number} меньше нуля. введите другие число.");
                }
            }
            return number;
        }

        static int GetRandomNumber(int minNumb, int maxNumb)
        {
            Random random = new Random();
            int number = random.Next(minNumb,maxNumb);

            return number;
        }

        static void Print(Queue<int> checks, int maxCheck)
        {
            int endSumm = 0;

            for (int i = 0; i < maxCheck; i++)
            {
                int tempCheck;

                tempCheck = checks.Dequeue();
                endSumm = endSumm + tempCheck;
                PrintSumm(endSumm, tempCheck);
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Посетители закончились, сума денег в кассе - {endSumm}");
        }

        static void PrintSumm(int endSumm, int tempCheck)
        {
            Console.WriteLine($"Размер чека - {tempCheck}");
            Console.WriteLine($"Сумма денег в кассе - {endSumm}");
        }
    }
}
