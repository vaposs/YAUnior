using System;
using System.Collections.Generic;
using System.Globalization;

namespace Project_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int endSumm = 0;
            Queue<int> checks = new Queue<int>();

            Console.Write("Введите количество чеков в очереди - ");
            int maxChecks = GetPositiveNumber();
            FillQueue(checks, maxChecks);

            while (checks.Count > 0)
            {
                Console.WriteLine($"Размер чека - {checks.Peek()}");
                endSumm += ServeNumberQueue( endSumm ,checks);
                Console.WriteLine($"Сумма денег в кассе - {endSumm}");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Посетители закончились, сума денег в кассе - {endSumm}");
        }

        static void FillQueue(Queue<int> checks, int maxChecks)
        {
            int randomNumber;
            Random random = new Random();

            Console.Write("Введите минимальную сумму чека - ");
            int minimumNumb = GetPositiveNumber();
            Console.Write("Введите максимальную сумму чека - ");
            int maximumNumb = GetPositiveNumber();

            for (int i = 0; i < maxChecks; i++)
            {
                randomNumber = random.Next(minimumNumb, maximumNumb);
                checks.Enqueue(randomNumber);
            }
        }

        static int GetPositiveNumber()
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

        static int ServeNumberQueue(int check, Queue<int> checks)
        {
            check = checks.Dequeue();

            return check;
        }
    }
}