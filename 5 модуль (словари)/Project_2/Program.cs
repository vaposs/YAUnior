using System;
using System.Collections.Generic;
using System.Globalization;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int summ = 0;
            Queue<int> checks = new Queue<int>();

            Console.Write("Введите количество чеков в очереди - ");
            int maxChecks = GetPositiveNumber();
            FillQueue(checks, maxChecks);

            while (checks.Count > 0)
            {
                int currentCheck = checks.Dequeue();
                Console.WriteLine($"Размер чека - {currentCheck}");
                summ += currentCheck;
                Console.WriteLine($"Сумма денег в кассе - {summ}");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Посетители закончились, сумма денег в кассе - {summ}");
        }

        static void FillQueue(Queue<int> checks, int maxChecks)
        {
            Random random = new Random();
            int minSum = 0;
            int maxSum = -1;

            while (minSum > maxSum)
            {
                Console.Write("Введите минимальную сумму чека - ");
                minSum = GetPositiveNumber();
                Console.Write("Введите максимальную сумму чека - ");
                maxSum = GetPositiveNumber();

                if (minSum > maxSum)
                {
                    Console.WriteLine("Минимальная сумма не может быть больше максимальной.");
                }
            }

            for (int i = 0; i < maxChecks; i++)
            {
                int randomNumber = random.Next(minSum, maxSum + 1);
                checks.Enqueue(randomNumber);
            }
        }

        static int GetPositiveNumber()
        {
            string line;
            int number;

            while (true)
            {
                line = Console.ReadLine();

                if (int.TryParse(line, out number) && number >= 0)
                {
                    return number;
                }

                Console.WriteLine($"Строка '{line}' не является числом или меньше нуля. Повторите ввод: ");
            }
        }
    }
}
