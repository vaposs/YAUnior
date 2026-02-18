using System;
using System.Collections.Generic;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string SummCommand = "summ";
            const string ExitProgramCommand = "exit";

            List<int> numbers = new List<int>();
            bool isWork = true;
            string command;

            while (isWork)
            {
                command = Console.ReadLine();

                if(command == SummCommand)
                {
                    Summ(numbers);
                }
                else if(command == ExitProgramCommand)
                {
                    isWork = false;
                }
                else
                {
                    AddNumber(numbers, command);
                }
            }
        }

        static void AddNumber(List<int> numbers, string line)
        {
            if (int.TryParse(line, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine($"строка {line} не является числом.");
            }
        }

        static void Summ(List<int> numbers)
        {
            int summ = 0;

            if (numbers.Count == 0)
            {
                Console.Write("Список пустой.");
            }
            else
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    summ += numbers[i];
                }
            }

            Console.WriteLine($"Сумма чисел равна - {summ}");
        }
    }
}
