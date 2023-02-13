using System;
using System.Collections.Generic;
using System.Globalization;

namespace Project_2
{

    /*
     * 3) bool isConversionSucceeded = true; - отвечает за конвертацию правельный ввод числа
     */

   

    class MainClass
    {
        public static void Main(string[] args)
        {
            Queue<int> checks = new Queue<int>();
            Console.Write("Введите количество чеков в очереди - ");

            int maxChecks = GetNumber();
            CreateQueue(checks, maxChecks);
            QueueService(checks, maxChecks);
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

        static void QueueService(Queue<int> checks, int maxCheck)
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
