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
            ServeNumberQueue(checks);
        }

        static void CreateQueue(Queue<int> checks, int maxChecks)
        {
            int randomNumb;
            Random random = new Random();

            Console.Write("Введите минимальную сумму чека - ");
            int minNumb = GetNumber();
            Console.Write("Введите максимальную сумму чека - ");
            int maxNumb = GetNumber();

            for (int i = 0; i < maxChecks; i++)
            {
                randomNumb = random.Next(minNumb, maxNumb);
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

        static void ServeNumberQueue(Queue<int> checks)
        {
            int endSumm = 0;

            while (checks.Count > 0)
            {
                Console.WriteLine($"Размер чека - {checks.Peek()}");
                Console.WriteLine($"Сумма денег в кассе - {endSumm += checks.Dequeue()}");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine($"Посетители закончились, сума денег в кассе - {endSumm}");
        }
    }
}