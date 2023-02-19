using System;
using System.Collections.Generic;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddNumberCommand = "addnumber";
            const string SummCommand = "printsumm";
            const string ExitProgramCommand = "exit";

            List<int> numbers = new List<int>();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"\nВведите команду \n");
                Console.WriteLine($"1.{AddNumberCommand}");
                Console.WriteLine($"2.{SummCommand}");
                Console.WriteLine($"4.{ExitProgramCommand}");

                Console.Write("\nВведите команду - ");

                string command;

                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddNumberCommand:
                        AddNumber(numbers);
                        break;

                    case SummCommand:
                        Summ(numbers);
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine($"{command} - такой команды нет.");
                        break;
                }
            }
        }

        static void AddNumber(List<int> numbers)
        {
            int number;

            number = GetNumber();
            numbers.Add(number);
        }

        static void Summ(List<int> numbers)
        {
            int endSumm = 0;

            if (numbers.Count == 0)
            {
                Console.Write("Список пустой.");
            }
            else
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    endSumm += numbers[i];
                }
            }

            Console.WriteLine($"Сумма чисел равна - {endSumm}");
        }

        static int GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isSuccess;
            int number = 0;

            while (isConversionSucceeded)
            {
                Console.Write("введите целое число - ");
                line = Console.ReadLine();

                if (int.TryParse(line, out number))
                {
                    number = Convert.ToInt32(line);
                    isConversionSucceeded = false;
                }
                else
                {
                    Console.WriteLine($"строка {line} не является числом.");
                }
            }

            return number;
        }
    }
}
