using System;

namespace Project_11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int conditionDigit = 7;
            int divisionRemainder = 5;
            int maxDigit = 100;

            Console.WriteLine($"Будем выводить числа с остатком от деления '{divisionRemainder}' и меньше чем '{maxDigit}'.");
            Console.WriteLine("Нажмите Enter для старта.");
            Console.WriteLine("Продолжить . . .");
            Console.ReadLine();

            for (int numberOfIterations = 0; maxDigit > numberOfIterations; numberOfIterations ++)
            {
                if((numberOfIterations % conditionDigit == divisionRemainder) && (numberOfIterations < maxDigit))
                {
                    Console.WriteLine($" Число - {numberOfIterations}");
                }
            }
            Console.WriteLine("Вывод окончен.");
        }
    }
}
